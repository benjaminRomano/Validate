# Validate
Validation library for C# that reduces boilerplate while making intent more clear.
Inspired by Apache Common Langs Validation.

Includes:
* ExclusiveBetween
* InclusiveBetween
* IsAssignableFrom
* IsInstanceOf
* IsTrue
* MatchesPattern
* NoNullElements
* NotBlank
* NotEmpty
* NotNull
* ValidIndex
* ValidState


### Examples
Example verifying string is not blank
``` C#
// Example of non-blank string validation without Validate
public void PrintString(String text) {
  if (text == null || text.Length == 0) {
    throw new ArgumentException("Text cannot be blank");
  }
  
  Console.Out.WriteLine("Text inputted: " + text);
}

// Non-blank string validation With Validate
public void printString(String text) {
  Validate.notBlank(text, "Text cannot be blank");
  Console.Out.WriteLine("Text inputted: " + text);
}
```

Example converting string to number
``` C#
// Converting string to integer without Validate
public int convertStringToNum(String text) {
  if (text == null) {
    throw new NullReferenceException("Text cannot be null");
  }
  
  int number;
  bool isNumeric = int.TryParse(text, out number);
  
  if (!isNumeric) {
    throw new ArgumentException(String.Format("Cannot convert {0} to number!", text));
  }
  
  return number;
}


// Converting string to integer with Validate
public int convertStringToNum(String text) {
  Validate.notNull(s1, "text cannot be null");
  
  int number;
  bool isNumeric = int.TryParse(text, out number);
  
  Validate.isTrue(isNumeric, "Cannot convert {0} to number!", text);
  
  return number;
}

```
