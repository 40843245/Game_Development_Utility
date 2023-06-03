/*

BASIC INFO:
file name: Logger_Script.cs
author: mathgeeksJay
demo: Available on GitHub 
https://github.com/40843245/Game_Development_Utility/blob/main/Unity/Logger/Filter/Demo.md

*/

/*
functionality:
Determine what kind of message will be displayed in in Unity Message Console.
*/

/*
LogFlag:
An enum that determines what kind of message will be displayed in Unity Message Console.
*/

/*
MyNumber:
A class that can:
1. Convert an integer to any base.

2. Add prefix to represent a number for system. 
Such as binary number must be started with 0b.
Such as octal number must be started with 0o.
Such as decimal number must be started with 0d.
Such as hexdecimal number must be started with 0x.

3. Complement the number.

4. Get the minimun number of bits if we represent the number with given base.

*/

/*
MyNumber:
Ulility function to get the flag with the number in myNumber instance, which its type is MyNumber class.
*/

/*
MyCustomLogger:
A class that determine message to log with the list in the property myNumber_Func which its type is MyNumber_Func class.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum LogFlag
{
    None = 0 ,
    Log = 1 ,
    Warning = 1 << 1 , 
    Error = 1 << 2 ,
    Exception = 1 << 3 
};

[Serializable]
public class MyNumber 
{
    private int originalNumber ;
    private int backupNumber;

    private int originalNumberLength;
    private int fromBase ; 
    private string originalNumberS;
    private string originalNumberSPrefix;
    private int maxNumber;

    public MyNumber(int fromBase = 10 , int originalNumber = 0 , int maxNumber = 1000)
    {
        this.originalNumber=originalNumber;
        this.fromBase=fromBase;
        this.maxNumber=maxNumber;
        this.originalNumberLength=MyNumber.GetLength(this.fromBase,this.maxNumber);
    }
    private void Backup()
    {
        this.backupNumber=this.originalNumber;
    }
    private void Restore()
    {
        this.originalNumber=this.backupNumber;
    }
    public int GetOriginalNumber()
    {
        return this.originalNumber;
    }

    public int GetBase()
    {
        return this.fromBase;
    }
    public int GetLength()
    {
        return this.originalNumberLength;
    }
    public static int GetLength(int fromBase, int originalNumber)
    {
        int positiveNum = Math.Abs(originalNumber);
        int i=0;
        int result = 1;
        for(i = 0 , result = 1; result < positiveNum ; i ++ )
        {
            result = result * fromBase;
        }
        return i;
    }

    public static int Complement(int fromBase,int originalNumber,int leng)
    {
        int result = (int) Math.Pow(fromBase,leng) - Math.Abs(originalNumber);
        return result;
    }
    public int Complement(bool setOriginalNumber = false)
    {
        int value=Math.Abs(this.originalNumber);
        int sign=Math.Sign(this.originalNumber);

        int result = MyNumber.Complement(this.GetBase(),value,this.originalNumberLength);
        result = (-1) * sign * result ;
        if(setOriginalNumber==true)
        {
            this.originalNumber=result;
        }
        return result;
    }

    public static string ConvertBase_Utility(int number,int fromBase,int leng)
    {
        string result;
        if(number == 0 )
        {
            return "0";
        }
        if(number > 0)
        { 
            result = Convert.ToString(number,fromBase);
            for(int i=result.Length;i<leng+1;i++)
            {
                result = "0" + result;
            }
        }else 
        {
            int complNumber=MyNumber.Complement(fromBase,number,leng);
            result = Convert.ToString(complNumber,fromBase);
            for(int i=result.Length;i<leng+1;i++)
            {
                result = "1"+result;
            }
        }
        return result ;
    }
    public string ConvertBase(bool prefixFlag = false)
    {
        string result = MyNumber.ConvertBase_Utility(this.originalNumber,this.fromBase,this.originalNumberLength);
        this.originalNumberS=result;
        switch(this.fromBase)
            {
                case 2:
                    this.originalNumberSPrefix="0b"+result;
                    break;
                case 8:
                    this.originalNumberSPrefix="0o"+result;
                    break;
                case 10:
                    this.originalNumberSPrefix="0d"+result;
                    break;
                case 16:
                    this.originalNumberSPrefix="0x"+result;
                    break;
                default:
                    this.originalNumberSPrefix=result;
                    break;
            }
            if(prefixFlag == true)
            {
                result = this.originalNumberSPrefix;
            }
        return result;
    }
}

[Serializable]
public class MyNumber_Func 
{
    private MyNumber myNumber;
    private List<int> be1_index_list=new List<int>();
    public MyNumber_Func(MyNumber myNumber)
    {
        this.myNumber=myNumber;
        this.SetMyNumber(this.myNumber);
    }
    public void SetMyNumber(MyNumber myNumber)
    {
        this.myNumber = myNumber;
        string numberS=MyNumber_Func.Compose(this.myNumber);
        this.be1_index_list=MyNumber_Func.UpdateList(numberS);
    }

    public static string Compose(MyNumber myNumber)
    {
        string numberS=myNumber.ConvertBase();
        return numberS;
    }
    public static List<int> UpdateList(string numberS)
    {
        List<int> list=new List<int>();
        list.Clear();
        for(int i=numberS.Length-1;i>=0;i--)
        {
            if(numberS[i]=='1')
            {
                list.Add(numberS.Length-1-i);
            }
        }
        return list;
    }
    public List<int> GetList()
    {
        return be1_index_list;
    }
    public static void PrintList(List<int> list)
    {
        string message="";
        message+="\n";
        for(int i=0;i<list.Count;i++)
        {
            message+=(list[i]+"\n");
        }
        Debug.Log(message);
    }
}
[Serializable]
public class MyCustomLogger 
{
    public MyNumber_Func myNumber_Func;
    public MyCustomLogger(MyNumber myNumber)
    {
        this.myNumber_Func = new MyNumber_Func(myNumber);
    }
    public void SetMyNumber(MyNumber myNumber)
    {
        this.myNumber_Func = new MyNumber_Func(myNumber);
    }
    private bool ListContain(int item)
    {
        return this.myNumber_Func.GetList().Contains(item);
    }

    public void Log(string message)
    {
        if(ListContain(0) == true)
        {
            Debug.Log(message);
        }
    }

    public void LogFormat(string message,Type format)
    {
        if(ListContain(0) == true)
        {
            string s = string.Format(message,format);
            Debug.Log(message);
        }
    }

    public void LogWarning(string message)
    {
        if(ListContain(1) == true)
        {
            Debug.LogWarning(message);
        }
    }
    public void LogWarningFormat(string message,Type format)
    {
        if(ListContain(1) == true)
        {
            string s = string.Format(message,format);
            Debug.LogWarning(message);
        }
    }

    public void LogError(string message)
    {
        if(ListContain(2) == true)
        {
            Debug.LogError(message);
        }
    }
    public void LogErrorFormat(string message,Type format)
    {
        if(ListContain(2) == true)
        {
            string s = string.Format(message,format);
            Debug.LogError(message);
        }
    }
    public void LogException(Exception exception)
    {
        if(ListContain(3) == true)
        {
            Debug.LogException(exception);
        }
    }
}

public class Logger_Script : MonoBehaviour
{
    [SerializeField]
    private MyCustomLogger myCustomLogger;
    void Start()
    {
        Init();
    }
    void Init()
    {
        int maxNumber = 16;
        int flag = (int)LogFlag.Log + (int)LogFlag.Error;
        MyNumber myNumber = new MyNumber(2,flag,maxNumber);
        myCustomLogger = new MyCustomLogger(myNumber);
        myCustomLogger.Log("Hello");
        myCustomLogger.LogWarning("Hello");
        myCustomLogger.LogError("Hello");
    }        
}
