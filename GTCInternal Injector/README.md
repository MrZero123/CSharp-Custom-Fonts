# Custom Font System - GTCInternal Injector

This document explains how to use the custom font system in the GTCInternal Injector project.

## 🎨 Font Setup

1. Place your font file (e.g., `SuperFunky-lgmWw.ttf`) in the project root directory
2. Make sure the font file is set to "Copy to Output Directory" in properties

## 🔍 Finding Custom Fonts

You can find a wide variety of free fonts at [FontSpace](https://www.fontspace.com/popular/fonts). The website offers:
- Over 140,000 free fonts
- 19,000+ commercial-use fonts
- Various categories including:
  - Sans Serif
  - Serif
  - Brush
  - Handwriting
  - Retro and Vintage
  - Graffiti
  - And many more!

When downloading fonts, make sure to check the license (Personal Use or Commercial Use) before implementing them in your project.

## 📝 Using Custom Fonts

### Preset Font Sizes

We have predefined font sizes for consistency:

```csharp
public enum FontSize
{
    Small = 12,      // Good for small text
    Medium = 16,     // Good for regular content
    Large = 24,      // Good for subtitles
    ExtraLarge = 32  // Good for main titles
}
```

### Quick Usage Examples

#### 1. Using Preset Sizes
```csharp
// Basic usage
SetCustomFont(label1, FontSize.Large, "Your Text");

// With different sizes
SetCustomFont(titleLabel, FontSize.ExtraLarge, "Main Title");
SetCustomFont(subtitleLabel, FontSize.Medium, "Subtitle");
SetCustomFont(contentLabel, FontSize.Small, "Content");

// With font styles
SetCustomFont(boldLabel, FontSize.Medium, "Bold Text", FontStyle.Bold);
SetCustomFont(italicLabel, FontSize.Medium, "Italic Text", FontStyle.Italic);
```

#### 2. Using Exact Sizes
```csharp
// For precise font sizes
SetCustomFontExact(customLabel, 18.5f, "Custom Size Text");
SetCustomFontExact(specialLabel, 22.5f, "Special Size", FontStyle.Bold);
```

### 🔄 Changing Fonts Dynamically

You can update font sizes at runtime:
```csharp
UpdateLabelFont(label1, FontSize.Small);  // Change to small
UpdateLabelFont(label1, FontSize.Large);  // Change to large
```

## 💡 Best Practices

1. Use preset sizes (`FontSize` enum) when possible for consistency
2. Use `SetCustomFontExact` only when you need a specific size
3. Always dispose of fonts properly (handled automatically in Form closing)
4. Set up initial fonts in `SetupInitialLabels()` method

## 🎯 Method Reference

### SetCustomFont
```csharp
SetCustomFont(Label label, FontSize size, string text = null, FontStyle style = FontStyle.Regular)
```
- `label`: The label to apply the font to
- `size`: Preset size from FontSize enum
- `text`: (Optional) Text to set
- `style`: (Optional) Font style (Bold, Italic, etc.)

### SetCustomFontExact
```csharp
SetCustomFontExact(Label label, float exactSize, string text = null, FontStyle style = FontStyle.Regular)
```
- `label`: The label to apply the font to
- `exactSize`: Exact font size (float)
- `text`: (Optional) Text to set
- `style`: (Optional) Font style (Bold, Italic, etc.)

## ⚠️ Troubleshooting

If the font doesn't load:
1. Check if the font file exists in the output directory
2. Make sure the font file name matches exactly
3. Check for any error messages in the popup dialogs

## 🔧 Memory Management

The system automatically handles font disposal when the form closes. No manual cleanup is required. 