using bguerreroS5.Repositories;
using bguerreroS5.utils;
using bguerreroS5.Models;

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

	private async void ListaPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is not Persona persona)
			return;

		var eliminar = await DisplayAlert(
			"Eliminar persona",
			$"¿Desea eliminar a {persona.Nombre}?",
			"Sí",
			"No");

		if (eliminar)
		{
			if (_personRepository.DeletePerson(persona))
			{
				lblStatusMessage.Text = $"La persona {persona.Nombre} fue eliminada.";
				CargarPersonas();
			}
			else
			{
				lblStatusMessage.Text = _personRepository.StatusMessage;
			}
		}

		ListaPersonas.SelectedItem = null;
	}

	private void CargarPersonas()
	{
		ListaPersonas.ItemsSource = _personRepository.GetAllPersons();
    }
}