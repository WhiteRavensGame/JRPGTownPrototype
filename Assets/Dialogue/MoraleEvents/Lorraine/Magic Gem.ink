EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL Changegold(value)

->START

== START ==
Magic Gem

Lorraine: “Hey kid, I’ve found a gem at a local auction that I really want to have for my collection but I need to borrow some money in order to get it. Can you let me borrow some money?”

->CHOICES

== CHOICES ==

 * [Loan 250 Wealth.] ->TWO_FIFTY
 * [Loan 500 Wealth.] ->FIVE_HUNDREDS
 * [Loan 1000 Wealth.] ->A_THOUSAND

== TWO_FIFTY ==
“Thanks kid, this’ll help.” 
~ Changegold(-250)
~ ChangeVillagerMorale(2, "Lorraine")
# +2% Lorraine Morale, -250 gold
->END

== FIVE_HUNDREDS ==
“Thank you Mayor! This will help me out tremendously at the auction.”
~ Changegold(-500)
~ ChangeVillagerMorale(5, "Lorraine")
# +5% Lorraine Morale, -500 gold
->END

== A_THOUSAND ==
“Thank you Mayor! This will help me get the ma… special gem at he auction.”
~ Changegold(-1000)
~ ChangeVillagerMorale(10, "Lorraine")
# +10% Lorraine Morale, -1000 gold
->END