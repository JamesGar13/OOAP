using System;
using System.Collections;
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

namespace ooap_lab8
{
    public class GeoNode
    {
        public string Name { get; set; }
        public List<GeoNode> Children { get; } = new List<GeoNode>();

        public GeoNode(string name)
        {
            Name = name;
        }

        public void AddChild(GeoNode child)
        {
            Children.Add(child);
        }
    }

    public class GeoIterator : IEnumerator<GeoNode>
    {
        private Stack<GeoNode> stack = new Stack<GeoNode>();
        private GeoNode current;

        public GeoIterator(GeoNode root)
        {
            stack.Push(root);
        }

        public GeoNode Current => current;
        object IEnumerator.Current => current;

        public bool MoveNext()
        {
            if (stack.Count == 0) return false;

            current = stack.Pop();

            for (int i = current.Children.Count - 1; i >= 0; i--)
                stack.Push(current.Children[i]);

            return true;
        }

        public void Reset() => throw new System.NotImplementedException();
        public void Dispose() { }
    }

    public static class GeoTreeBuilder
    {
        public static GeoNode BuildSampleTree()
        {
            var country = new GeoNode("Україна");

            var oblast1 = new GeoNode("Київська область");
            var oblast2 = new GeoNode("Львівська область");

            var rayon1 = new GeoNode("Обухівський район");
            var rayon2 = new GeoNode("Львівський район");

            var city1 = new GeoNode("Обухів");
            var city2 = new GeoNode("Львів");

            var street1 = new GeoNode("вул. Центральна");
            var street2 = new GeoNode("вул. Шевченка");
            var street3 = new GeoNode("вул. Франка");

            var num1 = new GeoNode("59");
            var num2 = new GeoNode("38");
            var num3 = new GeoNode("72");
            var num4 = new GeoNode("67");
            var num5 = new GeoNode("34");
            var num6 = new GeoNode("12");
            var num7 = new GeoNode("120");
            var num8 = new GeoNode("103");

            street1.AddChild(num1);
            street1.AddChild(num2);
            street1.AddChild(num3);
            street2.AddChild(num4);
            street2.AddChild(num5);
            street3.AddChild(num6);
            street3.AddChild(num7);
            street3.AddChild(num8);

            city1.AddChild(street1);
            city2.AddChild(street2);
            city2.AddChild(street3);

            rayon1.AddChild(city1);
            rayon2.AddChild(city2);

            oblast1.AddChild(rayon1);
            oblast2.AddChild(rayon2);

            country.AddChild(oblast1);
            country.AddChild(oblast2);

            return country;
        }
    }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private TreeViewItem CreateTreeViewItem(GeoNode node)
        {
            var item = new TreeViewItem { Header = node.Name, Tag = node };

            foreach (var child in node.Children)
            {
                item.Items.Add(CreateTreeViewItem(child));
            }

            return item;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();

            var root = GeoTreeBuilder.BuildSampleTree();
            var iterator = new GeoIterator(root);

            while (iterator.MoveNext())
            {
                ListBox.Items.Add(iterator.Current.Name);
            }
        }

        private void LoadTree_Click(object sender, RoutedEventArgs e)
        {
            TreeView.Items.Clear();

            var root = GeoTreeBuilder.BuildSampleTree();
            var rootItem = CreateTreeViewItem(root);
            TreeView.Items.Add(rootItem);
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (TreeView.SelectedItem is TreeViewItem selectedItem)
            {
                SelectedText.Text = $"Обрано: {selectedItem.Header}";
            }
        }
    }
}
