using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ooap_lab7
{
    public abstract class GUIComponent
    {
        protected GUIComponent Parent;

        public void SetParent(GUIComponent parent)
        {
            Parent = parent;
        }

        public virtual void HandleEvent(string eventType)
        {
            Parent?.HandleEvent(eventType);
        }
    }


    public class ButtonComponent : GUIComponent
    {
        private readonly string name;
        private readonly Action<string> log;

        public ButtonComponent(string name, Action<string> logAction)
        {
            this.name = name;
            log = logAction;
        }

        public override void HandleEvent(string eventType)
        {
            log($"Кнопка \"{name}\" отримала подію: {eventType}");
            base.HandleEvent(eventType);
        }
    }

    public class PanelComponent : GUIComponent
    {
        private readonly Action<string> log;

        public PanelComponent(Action<string> logAction)
        {
            log = logAction;
        }

        public override void HandleEvent(string eventType)
        {
            log("Панель отримала подію: " + eventType);
            base.HandleEvent(eventType);
        }
    }
    public class WindowComponent : GUIComponent
    {
        private readonly Action<string> log;

        public WindowComponent(Action<string> logAction)
        {
            log = logAction;
        }

        public override void HandleEvent(string eventType)
        {
            log("Вікно обробляє подію: " + eventType);
            MessageBox.Show("Вікно отримало подію: " + eventType);
        }
    }

           
    




    public partial class MainWindow : Window
    {
        private ButtonComponent button;
        private PanelComponent panel;
        private WindowComponent window;
        public MainWindow()
        {
            InitializeComponent();

            window = new WindowComponent(Log);
            panel = new PanelComponent(Log);
            panel.SetParent(window);

            button = new ButtonComponent("Save", Log);
            button.SetParent(panel);
        }
        private void Log(string message)
        {
            
            ListBox.Items.Add(message);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            Log("Подія створена: Click");
            button.HandleEvent("Click");
        }
    }
}
