using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerPlugin
{
    public abstract class ModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException("propertyExpression");

            MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("ラムダ式の内容がプロパティになっていません", "propertyExpression");

            RaisePropertyChanged(memberExpression.Member.Name);
        }

        protected void SetError(string message, string propertyName)
        {
            errors[propertyName] = message;
        }

        protected void ClearError(string propertyName)
        {
            errors.Remove(propertyName);
        }

        protected bool HasError()
        {
            return errors.Any();
        }

        #region IDataErrorInfo実装

        private Dictionary<string, string> errors = new Dictionary<string, string>();

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (errors.ContainsKey(columnName))
                    return errors[columnName];
                return null;
            }
        }
        #endregion
    }
}
