# Demo 
## Example 1
### Introduction
It only displays log message and error message.

The key of the code as shown here.

        int flag = (int)LogFlag.Log + (int)LogFlag.Error;
### Part of code
        int maxNumber = 16;
        int flag = (int)LogFlag.Log + (int)LogFlag.Error;
        MyNumber myNumber = new MyNumber(2,flag,maxNumber);
        myCustomLogger = new MyCustomLogger(myNumber);
        myCustomLogger.Log("Hello");
        myCustomLogger.LogWarning("Hello");
        myCustomLogger.LogError("Hello");
### Result
![image](https://github.com/40843245/Game_Development_Utility/assets/75050655/b69f5133-6c87-433f-85ab-be981f5bd077)
