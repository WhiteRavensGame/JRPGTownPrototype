EXTERNAL Changefood(value)
EXTERNAL Changemorale(value)
VAR troopsAssigned = 50

-> Start

== Start ==
In an odd manor two kobolds walk into town with sacks of food on a cart and ask for the mayor.
Two Kobolds: "Heya big man, we got some food for you if you’d like to partake. What’d ya say?"

-> Choices

== Choices ==
 * [I want food for myself] -> Myself
 * [I want enough for the village] -> Village
 * [I hate food] -> I_hate_food
 #Need 25 Food

== Myself ==
You ask for enough food for yourself and the kobolds happily supply. You notice envious gazes as you get food.
#+5 Food and -2% Morale
~ Changefood(5)
~ Changemorale(-2)
->END

== Village ==
You ask for enough food for the village and the kobolds happily supply. The town is happy for your decision.
#+25 food and +5% Morale
~ Changefood(25)
~ Changemorale(5)
->END   

== I_hate_food ==
The kobolds get angry at you and start insulting you, begin fighting!
#Starts at medium difficulty fight with 2 kobolds

{troopsAssigned >= 10: ->Win| {troopsAssigned < 10: ->Lose}}

== Win ==
"Alright you FOOD HATER, we'll leave!"
~ Changefood(10)
->END 

== Lose ==
“Serves you right you dumb FOOD HATER!”
~ Changefood(-10)
->END