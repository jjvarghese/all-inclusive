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

### SC 1.3.6: Identify Purpose (Level AAA)

- **Goal**: It is easier to operate and navigate content.
- **What to do**: Use code to indicate the meaning of all controls and other key information, where available.
- **Why it's important**: Some people with cognitive disabilities may not understand a control's purpose from the name alone.
- **Limitations**: A mobile app _cannot fully meet this requirement_ because it requires machine-detectable, consistent meaning across UIs which is not possible for an app to achieve (Even if you add SemanticProperties.Description, it only helps screen readers read out a description — it doesn't let user agents semantically map that to e.g. “given-name”, “delete-button”, or “search”.). Additionally, Maui doesn't expose enough accessibility elements directly to achieve some of these requirement, so to get close to achieving it we can use some native code. These are platform-specific and inconsistent across OS versions. There’s no unified way to define “this icon represents a search function” or “this section is a complementary region” in a way that meets SC 1.3.6 expectations. There's also no consistent cross platform way of achieving autofill for forms.
- **How this was implemented**: Partial compliance is achieved by setting landmark regions (ARIA) on the contentview with the help of native code. We need to use native code instead of SemanticProperties.Description, because doing that on wrapper views like ContentView MAUI will attempt to map that to AccessibilityLabel (for iOS) may not set IsAccessibilityElement = true on the underlying UIView meaning VoiceOver doesn't see it as a labelled region (similar issue with Android for its equivalent native property)

### SC 1.4.1: Use of Color (Level A)

- **Goal**: Color is not the only way of distinguishing information.
- **What to do**: Use information in addition to color, such as shape or text, to convey meaning.
- **Why it's important**: Not everyone sees colors or sees them the same way.
- **How this was implemented**: When validating forms, don't just make the field red, add some text as well.

### SC 1.4.11: Non-text Contrast (Level AA)

- **Goal**: Important visual information meets the same minimum contrast required for larger text.
- **What to do**: Ensure meaningful visual cues achieve 3:1 against the background.
- **Why it's important**: Some people cannot see elements with low contrast.
- **How this was implemented**: Entry fields should have contrasting borders, buttons contrasting background colours. 

### SC 1.4.3: Contrast (Minimum) (Level AA)
- **Goal**: Text can be seen by more people.
- **What to do**: Provide sufficient contrast between text and its background.
- **Why it's important**: Some people cannot read faint text.
- **How this was implemented**: Ensuring all text is contrasting - especially placeholder text which defaults to barely readable, and error text which a basic red doesn't contrast enough.