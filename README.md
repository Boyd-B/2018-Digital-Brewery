## Summary

### Category: SXA
[Video](https://youtu.be/DWhDZPbm2xU)

#### Module Purpose
SXA is a powerful new feature of Sitecore that helps speed up the creation of websites by providing reusable components, layouts, and templates.  However, the prebuilt components don’t always meet the users’ needs, so they must create their own custom component instead.  This is where SXA becomes a little more complicated.  Many new items and settings must be created in various locations within the content tree to create a single component.  The varied locations of these items make their creation and maintenance difficult.  Our module automates many of these steps and reorganizes the content tree so that item locations and related settings are in more intuitive locations.  We’ve accomplished this by adding several buttons to the home tab and creating a few custom components of our own.

#### Pre-Requisites
* Sitecore Experience Accelerator 1.6
* Sitecore PowerShell 4.7.2 (This is a pre-requisite of the Sitecore Experience Accelerator 1.6)

#### Item Component
The Item Component greatly simplifies the process of custom component creation. A user can right-click on the Components folder located under the Presentation item in the Tenant Site and select Insert. The user then selects the Item Component from the insert options. A PowerShell script creates the component and also creates a rendering variant folder, a default variant, and a style folder as child items of the component.  This makes future maintenance easy as all items are in one easy to find location.  After creating the new component, the user will need to add fields to the default rendering variant and assign the component to the available rendering for the SXA toolbox.

![Item Component](documentation/images/AddItemComponent.png?raw=true "Item Component")

#### Create JS/Sass
The “Create JS” and “Create Sass” buttons greatly simplify the process of creating new JavaScript and Sass files.  Clicking either of the buttons runs a PowerShell script which prompts the user to choose the theme to which to add the file to. The user is then prompted to enter a name for the new file.

![Create Assets](documentation/images/CreateAssets.png?raw=true "Create Assets")

#### Inline SVGs
Our Inline SVG component brings true SVG functionality to the Experience Editor.  This allows the experience editor to more accurately portray how styling will affect SVG images.
