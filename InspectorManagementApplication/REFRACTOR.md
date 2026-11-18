# Refactoring Summary

This document describes the refactoring performed in the InspectorManagementApplication to reduce duplicated XAML and improve layout consistency and maintainability.

## 1. Reusable StatusBadge Control

**Before:**

Status text and its background styling were written separately in the Dashboard and Inspection List pages.

```xml
<Border BackgroundColor="Orange">
    <Label Text="Pending" />
</Border>
```

Similar XAML had to be repeated for different statuses.

**After:**

Created a reusable `StatusBadge` ContentView with a bindable `Status` property.

```xml
<controls:StatusBadge Status="Pending" />
```

The control automatically updates its text and background colour based on the status.

**Benefit:** Avoids repeating status badge XAML and keeps status styling consistent.

## 2. Centralized Resource Dictionaries

**Before:**

Colours, font sizes, font families, and spacing values could be specified directly in individual XAML elements.

```xml
<Label
    Text="Dashboard"
    FontSize="28"
    FontFamily="PoppinsSemiBold" />
```

**After:**

Created separate resource dictionaries:

- `Colors.xaml`
- `FontSizes.xaml`
- `Spacing.xaml`
- `Styles.xaml`

These resources are reused throughout the application.

```xml
<Label
    Text="Dashboard"
    Style="{StaticResource PageTitleStyle}" />
```

**Benefit:** Reduces repeated styling values and makes application-wide design changes easier.

## 3. Simplified Dashboard and Inspection List Layouts

**Before:**

Page layouts contained repeated styling and layout properties for inspection information, including titles, site details, status, and scheduled dates.

**After:**

Used consistent Grid-based layouts with defined rows and columns to organize inspection information.

```xml
<Grid
    RowDefinitions="Auto,Auto,Auto"
    RowSpacing="{StaticResource MediumSpacing}">
    
    <!-- Inspection title and status -->
    <!-- Site details -->
    <!-- Priority and scheduled date -->

</Grid>
```

**Benefit:** Improves alignment, readability, and consistency while reducing unnecessary nested layout containers.

## Conclusion

The refactoring improved code readability, reduced repeated styling and status-related XAML, and made the application easier to maintain and extend.