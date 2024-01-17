# ConsoleMenuAPI

This API provides tools for creating console menus with different element types. Menu navigation is implemented. 

Supports [submenus](#insertedmenuitem) and [localization](#localization).

Console menu is basically a list of menu items with navigation that console menu drawer displays.
The menu processes console input related to menu navigation and exiting menu. Otherwise the input is prosessed by selected item itself.

Navigation controls:
- `UpArrow`: move cursor up
- `DownArrow`: move cursor down
- `Esc`: exit menu
- `Enter`: exit menu if [appropriate](#exitmenuitem) menu item is selected

## Creating console menu

There are several ways to create a console menu:
- Implement the abstract `ConsoleMenu` class.
- Use the `StandardConsoleMenu` class.

### ConsoleMenu

**Properties:**

`Drawer { get; }`
- Type: `ConsoleMenuDrawer`
- Access: protected
- Drawer that displays console menu.

`Items { get; }`
- Type: `MenuItemList`
- Access: protected
- List of `IMenuItem` elements.

`IsEnd { get; set; }`
- Type: `boolean`
- Access: protected
- Indicates whether the menu should stop dialog.

`CurrentPosition { get; }`
- Type: `int`
- Access: protected
- Index of the selected menu item.

`CurrentItem { get; }`
- Type: `IMenuItem`
- Access: protected
- The selected menu item.

`EndResult { get; protected set; }`
- Type: `MenuEndResult`
- Access: public
- Result of the menu dialog (`Exit` or `Further`).

**Methods** to get item's data with corresponding index in a child class:
- `GetBool(int index)`

Return value: `boolean`
- `GetInt(int index)`
  
Return value: `int`
- `GetInsertedMenu(ind index)`

Return value: `ConsoleMenu`

**Drawing methods:**
- `DrawMenu()`

Calls console drawer to displays this menu
- `Draw()`

Is called every time after input is processed. Sets console cursor to initial position and calls the `DrawMenu` method. 
Can be overrided in a child class.

Protected `Navigation(ConsoleKeyInfo info)` method is used to select the navigation input and process it. 
Return value: `boolean`. Indicates whether `ExitMenuItem` or `ContinueMenuItem` is selected or `Esc` key is pressed.
**Note:** it is independent from the `IsEnd` property. `IsEnd` can be used to stop the menu internally.

Protected `ProcessInputByItem(ConsoleKey input)` can be used to process the input by `CurremtItem`.

Abstract `ProcessInput(ConsoleKey input)` method should be implemented in a child class to process non navigational input.

To **start** a console menu use the `ShowDialog()` method that returns `EndResult` value.

### StandardConsoleMenu

Implements the `ConsoleMenu` class.

The whole non navigational input is processed be the selected item: the `ProcessInput` method simply calls the `ProcessInputByItem` method.

## Menu items

Every menu item implements `IMenuItem` interface.

`IMenuItem` **properties**:

`Visible { get; set; }`
- Type: `boolean`
- Indicates whether the drawer should display this item.

`Interactive { get; set; }`
- Type: `boolean`
- Indicates whether the menu should process input for this item.

`Name { get; }`
- Type: `string`
- Items's name.

`IMenuItem` **methods**:

`GetString()`
- Return value: `string`
- Gets item's string for the drawer to display.

`ProcessInput(ConsoleKey input)`
- Return value: `void`
- Processes console input

### Standard menu items

#### `BoolMenuItem`
- Value type: `boolean`

#### `DependencyBoolMenuItem`
- Value type: `boolean`
- Encapsulates `IList<DependencyItem>`. Depending on the item's value changes the `Visibility` property of items in the list.

#### `IntMenuItem`
- Value type: `int`

#### `InsertedMenuItem`
- Value type: `ConsoleMenu`

#### `StringListMenuItem`
- Value type: `int`
- Encapsulates `IList<string>`. Item's value is selected string's index in the list.

#### `ExitMenuItem`
- Has no value. Exits menu and sets `ConsoleMenu.EndResult` to `Exit`

#### `ContinueMenuItem`
- Has no value. Exits menu and sets `ConsoleMenu.EndResult` to `Further`

## Localization

Localization is provided by the static `Localization` class. It encapsulates a localization dictionary that consists of 

`<localization key, localization string>` 

type entries.
A localization dictionary should implement `ILocalizationDictionary` interface.

Localization key type: `int`

Localization string type: `string`

So a localization dictionary have to get a localization string associated with the specified key. Additionaly a localization dictionary has localization data for displaying some standard menu items (the `ServiceItemsLocalization` class).

The API supports two types of localization dictionary:
- ### internal localization dictionary
All data is stored directly in code. Provided by the `InternalLocalizationDictionary` class.
Data can be added with the `AddItem(int key, string value)` method.
The API has predefined `RusLangDictionary` and `EndLangDictionary`.
- ### external localization dictionary
All data is stored in a file. Provided by the `ExternalLocalizationDictionary` class. The constructor:

`ExternalLocalizationDictionary(Dictionary<int, string> dictionary)`

Localization data is stored in the `dictionary` parameter. The `ServiceItemsLocalization` data has to be included, otherwise exception is thrown.

The API natively supports reading localization data from XML file.
The `LocalizationDictionaryFromFile` class implements the `ILocalizationDictionary` interface and realizes reading data from a XML file and localization dictionary operations.
Custom support for different file types can be added by implementing the `ILocalizationFile` interface and throwing the instance into the constructor:

`LocalizationDictionaryFromFile(ILocalizationFile localizationFile)`

The structure of XML localization file is demonstrated below:

```xml
<localization>
  <dictionary lang="eng">
    <onTitle>On</onTitle>
    <offTitle>Off</offTitle>
  </dictionary>
  <dictionary lang="rus">
    <onTitle>Вкл</onTitle>
    <offTitle>Выкл</offTitle>
  </dictionary>
</localization>
```

`eng` and `rus` are localiation dictionary keys.

`onTitle` and `offTitle` are localization keys.

`String` localization key from XML file is converted to `int` key by getting string's HashCode.

## Item name

Localization of the item's name is provided by the `ItemName` class.
Item can have constant name or dynamic that changes depending on the current localization dictionary.

The following code sample demonstrates how to create a menu item with constant name:
```c#
BoolItem item = new BoolItem("Hide cursor", false)
```
To create an item with dynamic name use a localization key as shown:
```c#
int locKey = 8;
EngLangDictionary dictionary = new EngLangDictionary();
dictionary.Add(locKey, "Hide cursor");
Localization.ChangeLanguage(dictionary);
BoolItem item = new BoolItem(locKey, false);
```
For more convenient work with the XML localization use `KeyStringToHash` or `KeyStringToHashArray` classes:
```c#
string xmlKey = "hide";
KeyStringToHash key = new KeyStringToHash();
BoolItem item = new BoolItem(key[xmlKey], false)
```
