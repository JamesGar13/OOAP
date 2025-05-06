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

namespace ooap_lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Costume
    {
        public string CostumeType { get; }

        public Costume(string type)
        {
            CostumeType = type;
        }

        public override string ToString() => CostumeType;

    }

    public class CostumeFactory
    {
        private Dictionary<string, Costume> costumes = new Dictionary<string, Costume>();

        public Costume GetCostume(string type)
        {
            if (!costumes.ContainsKey(type))
                costumes[type] = new Costume(type);
            return costumes[type];
        }
    }
    public class Actor
    {
        public string Name { get; }

        public Actor(string name)
        {
            Name = name;
        }

        public string Perform(string sceneName, Costume costume)
        {
            return $"{Name} бере участь у сцені \"{sceneName}\" у костюмі \"{costume.CostumeType}\"";
        }
    }

    public class Scene
    {
        public string Name { get; set; }
        public string CostumeType { get; set; }
        public List<string> Performances { get; set; } = new List<string>();
    }


    public partial class MainWindow : Window
    {

        private List<Scene> scenes;
        private List<Actor> actors;
        private CostumeFactory factory = new CostumeFactory();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            SceneListBox.ItemsSource = scenes;
        }
        private void LoadData()
        {
            actors = new List<Actor>
            {
                new Actor("Актор 1"),
                new Actor("Актор 2"),
                new Actor("Актор 3")
            };

            scenes = new List<Scene>
            {
                new Scene { Name = "Битва при замку", CostumeType = "Лицар" },
                new Scene { Name = "Ярмарок", CostumeType = "Селянин" },
                new Scene { Name = "Бенкет", CostumeType = "Лорд" },
                new Scene { Name = "Засідка", CostumeType = "Лицар" },
                new Scene { Name = "Свято", CostumeType = "Селянин" }
            };

            foreach (var scene in scenes)
            {
                var costume = factory.GetCostume(scene.CostumeType);
                foreach (var actor in actors)
                {
                    scene.Performances.Add(actor.Perform(scene.Name, costume));
                }
            }
        }
        private void SceneListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (SceneListBox.SelectedItem is Scene scene)
            {
                PerformanceListBox.ItemsSource = scene.Performances;
            }
        }

    }
}
