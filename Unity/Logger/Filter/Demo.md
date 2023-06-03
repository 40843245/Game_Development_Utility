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

## Example 2
### Introduction
It only displays log message.

The key of the code as shown here.

        int flag = (int)LogFlag.Log;
### Part of code
        int maxNumber = 16;
        int flag = (int)LogFlag.Log;
        MyNumber myNumber = new MyNumber(2,flag,maxNumber);
        myCustomLogger = new MyCustomLogger(myNumber);
        myCustomLogger.Log("Hello");
        myCustomLogger.LogWarning("Hello");
        myCustomLogger.LogError("Hello");
### Result
![image](https://github.com/40843245/Game_Development_Utility/assets/75050655/9611a12b-cb31-45c7-901c-7b68d3605d6e)

## Example 3
### Introduction
It only displays warning message.

The key of the code as shown here.

        int flag = (int)LogFlag.Warning;
### Part of code
        int maxNumber = 16;
        int flag = (int)LogFlag.Warning;
        MyNumber myNumber = new MyNumber(2,flag,maxNumber);
        myCustomLogger = new MyCustomLogger(myNumber);
        myCustomLogger.Log("Hello");
        myCustomLogger.LogWarning("Hello");
        myCustomLogger.LogError("Hello");
### Result
![image](https://github.com/40843245/Game_Development_Utility/assets/75050655/e9703fb1-f134-4862-995a-a553d6e5d5f6)

## Example 4
### Introduction
It only displays log message, warning message and error message.

The key of the code as shown here.

        int flag = (int)LogFlag.Warning + (int) LogFlag.Error + (int) LogFlag.Log;
### Part of code
        int maxNumber = 16;
        int flag = (int)LogFlag.Warning + (int) LogFlag.Error + (int) LogFlag.Log;
        MyNumber myNumber = new MyNumber(2,flag,maxNumber);
        myCustomLogger = new MyCustomLogger(myNumber);
        myCustomLogger.Log("Hello");
        myCustomLogger.LogWarning("Hello");
        myCustomLogger.LogError("Hello");
### Result
![image](https://github.com/40843245/Game_Development_Utility/assets/75050655/dce5bd63-47c3-436d-aa1f-0820736004af)
