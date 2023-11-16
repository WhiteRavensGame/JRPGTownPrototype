
-> Start

== Start ==
Adelaine: Hey boss, there’s a pretty big guy at the gate, says he wants a challenge.
	You make your way to the town gate. The man is a gladiator: he bears the insignia of the champions of Railand’s Arena.
	“I come for a challenge, and you shall give me one”
	He points at you.
	“I challenge you, leader!”
	Your heart tightens
	“To a game of rock, paper, scissors!”
	Oh.


-> Choices

== Choices ==
 * [Rock] -> Rock
 * [Paper] -> Paper
 * [Scissors] -> Scissors

== Rock ==
 * [Win] -> Win_Rock
 * [Lose] -> Lose
#
->END

== Paper ==
 * [Win] -> Win_Paper
 * [Lose] -> Lose
->END

== Scissors ==
 * [Win] -> Win_Scissors
 * [Lose] -> Lose
->END

== Win_Rock ==
His hand shows scissors.
“Yes! At last I find a worthy opponent! Congratulations, warrior, you have bested me. Here lies your reward.”
+1000 Gold
#+1000 Gold
->END

== Win_Paper ==
His hand shows rock.
“Yes! At last I find a worthy opponent! Congratulations, warrior, you have bested me. Here lies your reward.”
+1000 Gold
#+1000 Gold
->END

== Win_Scissors ==
His hand shows paper.
“Yes! At last I find a worthy opponent! Congratulations, warrior, you have bested me. Here lies your reward.”
+1000 Gold
#+1000 Gold
->END

== Lose ==
	His hand shows paper..
“Bah, pathetic! I leave, now. The warrior to best me will be in another land…”
->END
