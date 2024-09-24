using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TasteMuseum.Core.Expressions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> ExAnd<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var combined = new ReplaceParameterVisitor(expr1.Parameters[0], parameter).VisitAndConvert(expr1.Body, "And");

            combined = Expression.AndAlso(combined, new ReplaceParameterVisitor(expr2.Parameters[0], parameter).VisitAndConvert(expr2.Body, "And"));
            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }
        private class ReplaceParameterVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _oldParam;
            private readonly ParameterExpression _newParam;

            public ReplaceParameterVisitor(ParameterExpression oldParam, ParameterExpression newParam)
            {
                _oldParam = oldParam;
                _newParam = newParam;
            }

            protected override Expression VisitParameter(ParameterExpression param)
            {
                return param == _oldParam ? _newParam : base.VisitParameter(param);
            }
        }
    }
}
