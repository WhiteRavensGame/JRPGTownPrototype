EXTERNAL Changemorale(value)

-> Start

== Start ==
#speaker: Will  #portrait: Will
"Mary, our baker put a pie on the Inn’s window sill, and someone stole it, and I don’t want to accuse anyone but I have a couple people in mind."
#speaker: Narrator  #portrait: Default
Who is it?

-> Choices

== Choices ==
#speaker: Narrator  #portrait: Default
Lergon Jeffors: He loves our pies and always jokes about how he can smell them from his window across the street.
Mr. Martin Martins: Walks by our pie cooling window on his daily walk, he also stole a fork from us once. He claimed that he just forgot it in his pocket when he left so that case is still wide open. 
Peter the Thief: His name is Peter the Thief, it just seems like good practice to consider the town thief in the case of something stolen. 


 * [Lergon Jeffors.] -> Lergon
 * [Mr.Martin Martins.] -> Martin
 * [Peter the Thief.] -> Peter

== Lergon ==
#speaker: Narrator  #portrait: Default
It was not Lergon and he is very offended you thought it was him.
...Yeah it was Peter the thief.
~ Changemorale(-5)
#-5% morale
->END

== Martin ==
#speaker: Narrator  #portrait: Default
It was not Mr. Martin and he is offended you thought it was him.
...Yeah it was Peter the thief.
~ Changemorale(-5)
#-5% morale
->END

== Peter ==
#speaker: Narrator  #portrait: Default
It was Peter the Thief, who would've thought.
~ Changemorale(5)
#+5% morale
->END