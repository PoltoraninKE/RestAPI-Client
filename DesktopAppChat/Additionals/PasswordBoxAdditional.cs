using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace DesktopAppChat.Additionals
{
    class PasswordBoxAdditional : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += OnPasswordBoxValueChanged;
        }

        public SecureString Password
        {
            get => (SecureString)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(nameof(Password), typeof(SecureString), typeof(PasswordBoxAdditional), new PropertyMetadata(OnSourcePropertyChange));

        private static void OnSourcePropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                var behavior = d as PasswordBoxAdditional;
                behavior.AssociatedObject.PasswordChanged -= OnPasswordBoxValueChanged;
                behavior.AssociatedObject.Password = string.Empty;
                behavior.AssociatedObject.PasswordChanged += OnPasswordBoxValueChanged;
            }
        }

        private static void OnPasswordBoxValueChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var behavior = Interaction.GetBehaviors(passwordBox).OfType<PasswordBoxAdditional>().FirstOrDefault();
            var binding = BindingOperations.GetBindingExpression(behavior, PasswordProperty);
            if (binding != null)
            {
                var property = binding.DataItem.GetType().GetProperty(binding.ParentBinding.Path.Path);
                property?.SetValue(binding.DataItem, passwordBox.SecurePassword, null);
            }
        }
    }
}
