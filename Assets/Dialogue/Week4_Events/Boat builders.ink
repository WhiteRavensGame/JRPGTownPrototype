EXTERNAL Changematerials(value)
EXTERNAL Changesilk(value)
EXTERNAL ChangeBuildingProduction(value, Name)
VAR silk = 25
VAR material = 25

->START

== START ==
Boat Builders

Oscar:
“Sir. There are three boat builders that came to me that are coincidentally brothers who all want to help remake the boats, what should we do?”

->CHOICES

== CHOICES ==

 * [Make smaller boats and save materials.] ->Small
 * [Add sails to the boats (If player has 25 Silk).] ->Sails
 * [Make larger boats (If player has 25 Materials).] ->Large

== Small ==
“Sir, the smaller boats gave us more materials to work with but I do think our fishing abilities have been limited.”
~ Changematerials(25)
~ ChangeBuildingProduction(-1, "Fishery")
->END

== Sails ==
{silk < 25: ->CHOICES}
“Sir, the boats that have sails seem to be working much better since we save more time traveing through the river.”
~ Changesilk(-25)
~ ChangeBuildingProduction(1, "Fishery")
->END

== Large ==
{material < 25: ->CHOICES}
“Sir, the larger boats have taken up a lot of materials but we’ve been able to collect much more fish at a time because of it.”
~ Changematerials(-25)
~ ChangeBuildingProduction(1, "Fishery")
->END