using bguerreroS5.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace bguerreroS5
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; set; }
        public App(PersonRepository repo)
        {
            InitializeComponent();
            PersonRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}