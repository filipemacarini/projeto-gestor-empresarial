namespace GestaoEmpresarial.Controls;

public partial class DataViewerControl : ContentView
{
	public static readonly BindableProperty InformationProperty =
		BindableProperty.Create(
			nameof(Information),
			typeof(string),
			typeof(DataViewerControl),
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				var control = (DataViewerControl)bindable;
				control.LbInformation.Text = (string)newValue;
			});

	public string Information
	{
		get => (string)GetValue(InformationProperty);
		set => SetValue(InformationProperty, value);
	}

	public static readonly BindableProperty StatusProperty =
		BindableProperty.Create(
			nameof(Status),
			typeof(Color),
			typeof(DataViewerControl),
			defaultValue: Color.FromArgb("#ffffff"),
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				var control = (DataViewerControl)bindable;
				control.RrStatus.BackgroundColor = (Color)newValue;
			});

	public Color Status
	{
		get => (Color)GetValue(StatusProperty);
		set => SetValue(StatusProperty, value);
	}

	public static readonly BindableProperty ValueProperty =
		BindableProperty.Create(
			nameof(Value),
			typeof(decimal),
			typeof(DataViewerControl),
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				var control = (DataViewerControl)bindable;
				control.LbValue.Text = $"R$ {newValue:F2}";
			});

	public decimal Value
	{
		get => (decimal)GetValue(ValueProperty);
		set => SetValue(ValueProperty, value);
	}

	public static readonly BindableProperty StatusIsVisibleProperty =
		BindableProperty.Create(
			nameof(StatusIsVisible),
			typeof(bool),
			typeof(DataViewerControl),
			defaultValue: true,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				var control = (DataViewerControl)bindable;
				control.RrStatus.IsVisible = (bool)newValue;
			});

	public bool StatusIsVisible
	{
		get => (bool)GetValue(StatusIsVisibleProperty);
		set => SetValue(StatusIsVisibleProperty, value);
	}

	public DataViewerControl()
	{
		InitializeComponent();
	}
}