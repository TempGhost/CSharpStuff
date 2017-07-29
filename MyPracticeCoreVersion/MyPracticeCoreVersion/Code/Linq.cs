using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyPracticeCoreVersion.Code
{
    public static class Linq 
    { 
        public static  IEnumerable<TSourse> where<TSourse>  ( this IEnumerable<TSourse> sourse,Func<TSourse,bool> perdicate)
        {

            return null;
        }

        public static void DisPlayTree(int indent,string message,Expression expression) //输出表达式树的方法
            //在编程中有表达式 
            //如 a+b=c 而表达式 中也可以包含表达式
            //故程序在编译时 会生成表达式树
        {
            string output = String.Format("{0} {1} ! NodeTyoe {2}; Expr: {3} ", "".PadLeft(indent, '>'), message,
                expression.NodeType, expression);
            indent++;
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    Console.WriteLine(output);
                    LambdaExpression lambdaEpr = (LambdaExpression) expression;
                    foreach (var parameterExpression in lambdaEpr.Parameters)
                    {
                        DisPlayTree(indent, "param", parameterExpression);
                    }
                    DisPlayTree(indent, "Body", lambdaEpr.Body);
                    break;
                case ExpressionType.Constant:
                    ConstantExpression constantsExpr = (ConstantExpression) expression;
                    Console.WriteLine("{0} Constan Value :{1}", output, constantsExpr.Value);
                    break;
                case ExpressionType.Parameter:
                    ParameterExpression parameterExpr = (ParameterExpression) expression;
                    Console.WriteLine("{0} ,Param Type :{1}", output, parameterExpr.Type.Name);
                    break;
                case ExpressionType.Equal:
                case ExpressionType.AndAlso:
                case ExpressionType.GreaterThan:
                    BinaryExpression binartExpr = (BinaryExpression) expression;
                    if (binartExpr.Method != null)
                    {
                        Console.WriteLine("{0} Method {1}", output, binartExpr.Method.Name);
                    }
                    else
                    {
                        Console.WriteLine(output);
                    }
                    DisPlayTree(indent, "Left", binartExpr.Left);
                    DisPlayTree(indent, "Right", binartExpr.Right);
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression memberExpr = (MemberExpression) expression;
                    Console.WriteLine("{0} Member Name :{1} ,Type : {2}", output, memberExpr.Member.Name,
                        memberExpr.Type.Name);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("{0} {1}", expression.NodeType, expression.Type.Name);
                    break;
            }
        }
    }
}