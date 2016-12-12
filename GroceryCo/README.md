## Running the Application

Open the solution in visual studio then run. 

It will automatically copy the data files and sample file to the output directory. 

The receipt will also be printed in the output directory with the format "Receipt-{GUID}.txt"

## Prices File

The prices file is located in.

```
 \Data\Products.txt
```

The file uses tab delimiter

The second column is the price and will only accept decimal number. 

The application is assuming that the entered data file is in correct format. That's why when parsing the file it uses a hard coded indexes with no validation.


## Promotions File

The promotions file is located in.

```
 \Data\Promotions.txt
```

The file uses tab delimiter

The 1st column is the id

The 2nd column is the quantity. This data must be an integer value only.

The 3rd column is the price. This column will only accept decimal number and use "free" for the free promotions, "%" for the percentage promotion

The 4th column is only applicable for free and percentage promotions. This column contains the quantity to apply the free or percentage promotion.

The 5th column is only applicable for percentage promotion. This will contain the percentage to apply. The value must be the whole number for example the percentage is 50% then enter 50 not .5

The application is assuming that the entered data file is in correct format. That's why when parsing the file it uses a hard coded indexes with no validation.


The sample promotions 'Apple': $0.50 Sale Price and Buy 3 'Apple' for $2.00 uses the same format where you enter 

```
{Id}{tab}{Quantity}{tab}{SalePrice}
```

for example converting the said promotions above will have this format

Apple{tab}1{tab}.50

Apple{tab}3{tab}2

That's why there are both using same calculation in the code

## Sample File

The prices file is located in.

```
 \Samples\Sample.txt
```

This will just contain a list of the products. Each product should be in one line.


## Notes

Both the percentage and free promotions are dynamic on how many are going to be free or will have a percentage discount. 

for example you can say 

Buy 2 'Apple' get 4 for free

Buy 4 'Orange' get 2 for 50% off


