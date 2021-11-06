# **Arabic numbers to Roman numerals**
 
<br/>

## **Introduction**

<br/>

The goal of this exercise is not simply to solve the problem but to also see how you approached this task to solve it. Explain your approach, assumptions, or problem resolution during the README file along with the code. Pay extra attention to the quality and readability of the code and testing.

<br/>

### **Task**

Create a class that will implement the following interface

```C#
    public interface IRomanNumeralGenerator { 
        string Generate(int number);
    }
```

The Generate method should be able to convert Arabic numbers to Roman numerals

<br/>

### **Example I/O**

|Input | Output|
|:---:|:---:|
|1     |    "I"|
|5     |    "V"|
|10    |    "X"|
|20    |    "XX"|
|3999  |    "MMMCMXCIX"|

<br/><br/>

# **My solution**

The solution contains two projects. One for functionality (coding) and one for testing.

<br/>

The idea is - that I am creating a part of an extendable number conversion application. That can convert Arabic format numbers to Roman numerals and other types like hexadecimal numbers and vice versa as the project advances. That said, I would rename the given interface to INumberConvertor, so it is not only connected to Roman numerals, and the implementation would make more sense when creating classes like RomaanNumeralGenerator and HexadecimalNumberGenerator. But for the purpose of the task - I left it as it is.

Everything is neatly wrapped into regions to make the readability and potential refactoring of the code easier. And every class, interface and method has their XML documentation.

<br/>

### **Coding**

So I made a class called RomanNumeralGenerator, that implements the previously given IRomanNumeralGenerator interface.

The class contains a dictionary with specifically picked out conversions from Arabic numbers to Roman numerals.

```C#
protected readonly Dictionary<int, string> RomanLetters = new Dictionary<int, string>
    {
        {1000, "M" },
        {900, "CM" },
        {500, "D" },
        {400, "CD" },
        {100, "C" },
        {90, "XC" },
        {50, "L" },
        {40, "XL" },
        {10, "X" },
        {9, "IX" },
        {5, "V" },
        {4, "IV" },
        {1, "I" }
    };
```
Numbers like [1;5;10;50;100;500;1000] are pretty self-explanatory because they all are represented by a single character
<br/>
Numbers like 4 and 9 (or 40, 90 etc) are the only cases when a smaller value numeral will be in front of a bigger one (IV, IX), so these cases are also added to the dictionary for the algorithm to work.

<br/>



#### **Algorithm**

The algorithm for the problem is fairly simple
<br/>

##### **Pseudo code**

```
LET result be an empty String

if given integer <=0 or >= 4000
    throw argument out of range exception

while given integer > 0
    foreach key in the premade dictionary
        if given integer >= key
            subtract key from the given integer
            append the result string with the corresponding dictionary[key] value
            break 
```
<br/>

##### **Explenation**


If the given integer is within the allowed range ([1:3999]) then it slowly gets reduced to zero. It loops through all of the premade dictionary keys and if the key is bigger than the given integer, then it gets subtracted from it. And a corresponding dictionary value gets appended to the resulting string. Repeat the process until the given number is 0.

<br/>

#### **Multi language options**

Altho there is currently only one custom message in the whole task, the application is built for a multi-language possibility. It is using resource files to create consistency throughout the application and creating the possibility to achieve multiple languages (multi-language is not currently implemented)

### **Testing**

Unit testing followed the AAA principle (Arrange, Act, Assert). In this case, no 'Act' was needed. 

Why not Test Driven Development? Purely for my own comfort.

The tool used for unit testing - NUnit 3

Testing was cut into three blocks
* Argument out of range cases
* Given example cases
* Random generated tests

#### **Argument out of range tests**

These tests are for checking how the 'Generate' method handles numbers that are not in the allowed range. Cases like - if the passed number is a 0, below 0 or higher than 3999.

#### **Given example tests**

These tests include the example I/O cases which also includes the minimum and maximum allowed number (1 and 3999). So edge case tests are also in this block by default.

#### **Random generated tests**

In random tests, a random number is between 1 and 3999 (technically could do from 2 to 3998, because in the given example test cases contain 1 and 3999). A total of 2000 random tests get generated, to cover from 35% to 50% of all possible outcomes with less amount of being biased (choosing easy numbers, for example, 1000 would be, just M).

This testing block uses a dictionary that contained all conversions from Arabic numbers (as key) to Roman numerals (as value) in the range of [1:3999]. So an entry from the dictionary should be the same as the result from 'Generate' method.