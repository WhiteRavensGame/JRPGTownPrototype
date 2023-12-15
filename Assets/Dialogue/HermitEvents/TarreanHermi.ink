EXTERNAL ChangeBuildingProduction(value, Name)
EXTERNAL Changemorale(value)
EXTERNAL Changesilk(value)
EXTERNAL Changefood(value)
EXTERNAL Changematerials(value)

One day, from the valley wilderness a woman with tangled, orange hair comes to your village and requests an audience with you. They speak with fervor as they ask for your help with rebuilding their home which broke down. Additionally, they are in need of more clothes and food. Do you help?

* [I will help]
“The woman seems pleased with your help and accepts. She gives a nod before taking the supplies and leaving the village. Your act of kindness does not go unnoticed by the residents of town”
~ Changemorale(5)
~ ChangeBuildingProduction(1, "Mine")


* [I won’t help]
“The woman seems displeased about your refusal and leaves the village.”
~ Changemorale(-5)
~ ChangeBuildingProduction(-1, "Mine")

* [Stay here in the village]
“She smiles but shakes her head, indicating she doesn’t want to remain in the village. She thanks you for your kindness and wishes you a good harvest.”
~ Changemorale(5)
~ ChangeBuildingProduction(2, "Mine")

* [Offer more help]
“She smiles and nods, showing she accepts your offer. Others see your kindness to this hermit, and think better of you.”
~ Changesilk(-5)
~ Changematerials(-5)
~ Changefood(-5)
~ Changemorale(10)
~ ChangeBuildingProduction(3, "Mine")
-> END
