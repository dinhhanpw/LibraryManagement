using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LibraryManagement.ViewModel
{
    public class ValidatableBindableBase<T> : BindableBase, INotifyDataErrorInfo
    {
        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public static AbstractValidator<T> validator;

        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName)) return null;

            return _errors[propertyName];
        }

        protected virtual void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void RaiseErrorChangedOnProperty(string propertyName, T obj)
        {
            ValidateProperty(propertyName, obj);
            OnErrorChanged(propertyName);
        }

        public void ValidateProperty(String propertyName, T obj)
        {
            ValidationResult result = validator.Validate(obj, ruleSet: propertyName);
            if (!result.IsValid)
            {
                _errors[propertyName]
                    = result.Errors
                    .Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }
        }


        public void SetValidatableProperty<E>(ref E property, E value, T obj, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(property, value)) return;

            SetBindableProperty(ref property, value, propertyName);
            ValidateProperty(propertyName, obj);
            OnErrorChanged(propertyName);
        }
    }
}
