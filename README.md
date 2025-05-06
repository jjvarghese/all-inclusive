# All Inclusive
A MAUI app showcasing **Web Content Accessibility Guidelines** (WCAG) 2.1 compliance.

This app is fully WGAG 2.1 compliant: 

### SC 1.3.4: Orientation (Level AA)

- **Goal**: Devices can be used in any orientation.
- **What to do**: Don't lock content to either portrait or landscape presentation. Upside down support is **not** necessary.
- **Why it's important**: Wheelchair users and others may have devices mounted in a fixed orientation.
- **How this was implemented**: The app uses a dynamic UI and is able to switch between portrait and landscape dynamically.

### SC 1.3.5: Identify Input Purpose (Level AA)

- **Goal**: It is easier to fill out forms.
- **What to do**: Use code to indicate the purpose of common inputs, where technology allows.
- **Why it's important**: Some people with cognitive disabilities may not understand the input's purpose from the label alone.
- **How this was implemented**: As a mobile app and not a website, this is fulfilled by using accessibility properties (SemanticProperties.Description) and clear labelling, *but* native platforms don’t yet support all WCAG-required semantics (like HTML’s autocomplete="email"), so it’s more about naming, labelling, and consistency.






