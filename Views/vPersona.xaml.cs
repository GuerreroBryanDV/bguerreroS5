using bguerreroS5.Repositories;
using bguerreroS5.utils;

namespace bguerreroS5.Views;

public partial class vPersona : ContentPage
{
	private readonly PersonRepository _personRepository;

	public vPersona()
	{
		InitializeComponent();
		_personRepository = new PersonRepository(
			FileAcccesHelper.GetLocalFilePath("personas.db3"));
		CargarPersonas();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		var nombre = txtName.Text?.Trim();

		if (string.IsNullOrWhiteSpace(nombre))
		{
			lblStatusMessage.Text = "Ingrese un nombre.";
			return;
		}

		_personRepository.AddNewPerson(nombre);
		lblStatusMessage.Text = _personRepository.StatusMessage;
		txtName.Text = string.Empty;
		CargarPersonas();
	}

	private void btnMostrar_Clicked(object sender, EventArgs e)
	{
		CargarPersonas();
		lblStatusMessage.Text = $"{ListaPersonas.ItemsSource.Cast<object>().Count()} persona(s) encontrada(s).";
	}

	private void CargarPersonas()
	{
		ListaPersonas.ItemsSource = _personRepository.GetAllPersons();
    }
}