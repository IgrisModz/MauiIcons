using System.Runtime.CompilerServices;
using System.Text;

namespace MauiIcons.Sample.Controls;

public partial class CodeBlock : ContentView
{
	public static readonly BindableProperty CodeProperty =
		BindableProperty.Create(nameof(Code), typeof(string), typeof(CodeBlock), string.Empty, propertyChanged: OnCodeChanged);

	public static readonly BindableProperty LanguageProperty =
		BindableProperty.Create(nameof(Language), typeof(string), typeof(CodeBlock), "xml");

	public string Code
	{
		get => (string)GetValue(CodeProperty);
		set => SetValue(CodeProperty, value);
	}

	public string Language
	{
		get => (string)GetValue(LanguageProperty);
		set => SetValue(LanguageProperty, value);
	}

	public CodeBlock()
	{
		InitializeComponent();

		if (Application.Current != null)
		{
			Application.Current.RequestedThemeChanged += (s, e) => UpdateWebView();
		}
	}

	static void OnCodeChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is CodeBlock codeBlock)
		{
			codeBlock.UpdateWebView();
		}
	}

	protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		base.OnPropertyChanged(propertyName);

		if (propertyName == nameof(Language))
		{
			UpdateWebView();
		}
	}

	void UpdateWebView()
	{
		if (string.IsNullOrEmpty(Code))
		{
			return;
		}

		var isDarkTheme = Application.Current?.RequestedTheme == AppTheme.Dark;

		// Couleurs de fond pour correspondre à l'IDE VS 2022/2026
		var backgroundColor = isDarkTheme ? "#1e1e1e" : "#ffffff";

		// On utilise prism-vs.min.css pour le clair et prism-vsc-dark-plus pour le sombre (très proche de VS 2022+)
		var themeCssUrl = isDarkTheme
			? "https://cdnjs.cloudflare.com/ajax/libs/prism-themes/1.9.0/prism-vsc-dark-plus.min.css"
			: "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/themes/prism-vs.min.css";

		var html = $@"
<!DOCTYPE html>
<html>
<head>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <link rel='stylesheet' href='{themeCssUrl}'>
    <style>
        body {{
            margin: 0;
            padding: 10px;
            background-color: {backgroundColor};
            font-family: 'Consolas', 'Cascadia Code', monospace;
            font-size: 13px;
        }}
        pre {{ margin: 0 !important; background: transparent !important; }}
        code {{ background: transparent !important; }}
        
        /* Ajustements pour le XAML moderne (VS 2022/2026) */
        .token.tag {{ color: {(isDarkTheme ? "#569cd6" : "#a31515")}; }}
        .token.attr-name {{ color: {(isDarkTheme ? "#9cdcfe" : "#ff0000")}; }}
        .token.attr-value {{ color: {(isDarkTheme ? "#ce9178" : "#0000ff")}; }}
        .token.punctuation {{ color: #808080; }}
        /* Couleur spécifique pour les {{Binding}} */
        .token.attr-value > .token.punctuation:first-child,
        .token.attr-value > .token.punctuation:last-child {{ color: #4ec9b0; }}
    </style>
</head>
<body class='language-{Language}'>
    <pre><code class='language-{Language}'>{System.Security.SecurityElement.Escape(Code)}</code></pre>

    <script src='https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/prism.min.js'></script>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/components/prism-xaml.min.js'></script>

    <script>
        // Forcer Prism à mettre en évidence le code
        Prism.highlightAll();

        function updateHeight() {{
            var height = document.body.scrollHeight;
            window.location.href = 'app://resize/' + height;
        }}
        window.onload = updateHeight;
        setTimeout(updateHeight, 200);
    </script>
</body>
</html>";

		webView.Source = new HtmlWebViewSource { Html = html };
	}
}
