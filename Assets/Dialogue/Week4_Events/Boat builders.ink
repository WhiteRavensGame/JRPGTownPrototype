EXTERNAL Changematerials(value)
EXTERNAL Changesilk(value)
EXTERNAL ChangeBuildingProduction(value, Name)
VAR silk = 25
VAR material = 25

->START

== START ==
#speaker: Oscar #portrait: Oscar
“Sir. There are three boat builders that came to me that are coincidentally brothers who all want to help remake the boats, what do you want to do?”

->CHOICES

== CHOICES ==

 * [Make smaller boats and save materials.] ->Small
 * [Add sails to the boats.] ->Sails
 # Need at least 25 silk
 * [Make larger boats.] ->Large
 # Need at least 25 materials

== Small ==
#speaker: Oscar #portrait: Oscar
“Sir, the smaller boats gave us more materials to work with but I do think our fishing abilities have been limited.”
~ Changematerials(25)
~ ChangeBuildingProduction(-1, "Fishery")
->END

== Sails ==
{silk < 25: ->CHOICES}
#speaker: Oscar #portrait: Oscar
“Sir, the boats that have sails seem to be working much better since we save more time traveing through the river.”
~ Changesilk(-25)
~ ChangeBuildingProduction(1, "Fishery")
->END

== Large ==
{material < 25: ->CHOICES}
#speaker: Oscar #portrait: Oscar
“Sir, the larger boats have taken up a lot of materials but we’ve been able to collect much more fish at a time because of it.”
~ Changematerials(-25)
~ ChangeBuildingProduction(1, "Fishery")
->END