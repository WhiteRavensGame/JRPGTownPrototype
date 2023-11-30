
-> Start

== Start ==
Oscar: "Mayor. I’m at the end of my fishing lines. Need silk to make more. I’d get it myself but uh… I need to fish. Can you go get some?"

-> Choices

== Choices ==
 * [Give 5 Silk] -> 5_Silk
 * [Give 10 Silk] -> 10_Silk
 * [Give 25 Silk] -> 25_Silk

== 5_Silk ==
Thanks, Mayor. That’ll do.
#+5 food
->END

== 10_Silk ==
Thanks, Mayor. That’ll do. 
He seems happy
#+10 food and +%2 Morale
->END

== 25_Silk ==
Huh. Thanks, Mayor. That’ll do.
He looks really happy.
#+25 food and +%5 Morale
->END