->START

== START ==
Big Bass

Oscar: “Mayor. Big bass has shown up in the river. Been eating all the fish. Could even call it a boss. Need to do something about it.”

->CHOICES

== CHOICES ==

 * [Fight Bass (Easy Battle).] ->FIGHT
 * [Fish for Bass.] ->FISH
 * [Do nothing.] ->DO_NOTHING

== FIGHT ==
* [Win.] ->WIN
* [Lose.] ->LOSE

->DONE

== WIN ==
“Hm. That’s a lot of food. Good work.”
# +5% Oscar Morale, +10 Food
->END

== LOSE ==
“That’s a setback.”
# -5% Oscar Morale, -3 Troops, -10 Food
->END

== FISH ==
“We got it. Ate up all our damn bait but we got it."

# +2% Oscar Morale, +5 food
->END

== DO_NOTHING ==
“Bloody fish ate up all the fish for a whole week. Even destroyed a portion of the docks, have to fix it. Finally gone though.”

# -10 Food. -5 Materials, and -5% Oscar Morale
->END
