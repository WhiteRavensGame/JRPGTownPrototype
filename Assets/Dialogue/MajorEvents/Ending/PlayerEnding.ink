VAR fightChoice = true
VAR bribeChoice = true
VAR trickChoice = true

VAR troops = 50
VAR morale = 75
VAR gold = 5000
VAR food = 50
VAR material = 50
VAR silk = 50

VAR endingName = ""

{troops >= 50 && morale >= 75: ->GoodFight}
{troops >= 10: ->MidFight | ->BadFight}

{food >= 50 && material >= 50 && silk >= 50 && morale >= 75: ->GoodTrick |}
{food >= 50 && material >= 50 && silk >= 50 && morale <= 75: ->MidTrick }
{food < 50 && material <= 50 && silk <= 50 && morale <= 75:-> BadTrick}

{gold >= 5000 && morale >= 75: ->GoodBribe}
{gold >= 5000 && morale <= 75: ->MidBribe}
{gold <= 5000 && morale <= 75: -> BadBribe}


==GoodFight==
    You return to Steadville, to face the grave faces of your citizens. You announce the news: the town is your home, and you will fight to defend it. Some sigh in resignation, but what you see reflected in most of their eyes is unbreakable will. 
During the night, the whole town sets up the final preparation: trenches are dug and traps are laid down by Roe and their men, aided by Adelaine’s smithy team. Oscar helps give the troops a final round of training, while Lorraine gathers all those who can’t fight in her shop. He is afraid, but even Will grabs a sword and trains under Oscar’s protection. Then, the light of dawn sets the horizon aflame.
		After a brief moment of calm, that which comes before all storms, the drums of war sound in the valley, and the army descends upon Steadville. What follows is confusion. Waves after waves of soldiers come crashing upon your one line of defense. Somehow, despite the limits of possible you survive the first assault. Then the next, then the next. After what feels like either seconds or hours, you’re not sure, another, lighter horn resounds, and the Leirrus troops start retreating.
	You’re never certain what happened: maybe your resistance was fierce enough that destroying Steadville wasn’t worth it, or maybe they found another way through the mountains, or maybe a god struck down their general, who knows. What matters is that Steadville still stands, that your friends are alive and well, and that it was in the greater part thanks to your leadership. Congratulations, mayor.
	~ endingName = "GoodFight"

-> END

==MidFight==
You return to Steadville, to face the grave faces of your citizens. You announce the news: the town is your home, and you will fight to defend it. You hear some sighs, some cries, and when you look in your citizens eyes, you see only quiet resignation. 
During the night, the whole town sets up the final preparation: trenches are dug and traps are laid down by Roe and their men, aided by Adelaine’s smithy team. Oscar reluctantly helps give the troops a final round of training, while Lorraine gathers all those who can’t fight in her shop. Will locks himself in the tavern and refuses to come out Then, dawn sets the horizon aflame.
After a brief moment of calm, that which comes before all storms, the drums of war sound in the valley, and the army descends upon Steadville. What follows is chaos. Your troops fight, and they fight well, but there are so many. When the line is breached, you fight in the streets, and in the buildings. After what feels like either seconds or hours, you’re not sure, you suddenly realize that no soldier is coming anymore. When you look where the army used to be, you realize that there are only the fields you are used to: the army has passed, and your town has survived. 
Many had died, the town was half destroyed, but thanks to your leadership, it was still standing, and it would be rebuilt. The rest of the war would go in ways that do not concern you now: Steadville survived. Congratulations, mayor.
	~ endingName = "MidFight"
->END

==BadFight==
You return to Steadville, to face the grave faces of your citizens. You announce the news: the town is your home, and you will fight to defend it. You hear some sighs, some cries, and when you look in your citizens eyes, you see only quiet resignation. 
	During the night, the whole town sets up the final preparation: trenches are dug and traps are laid down by Roe and their men, aided by Adelaine’s smithy team. Oscar reluctantly helps give the troops a final round of training, while Lorraine gathers all those who can’t fight in her shop. Of Will, nothing is seen: the Inn is locked shut and his belongings are gone. Then, dawn sets the horizon aflame.
After a brief moment of calm, that which comes before all storms, the drums of war sound in the valley, and the army descends upon Steadville. What follows is chaos. Your militia does what it can, but there are so many. Soon enough, the first line of defense is breached, then the second, then  people are fighting in the streets, then in the houses. Then it is not fighting anymore. It is running, or dying. The nightmare lasts for what feels like hours, until the army has at last passed. 
The town is burnt, the land salted, most of your friends are dead, or taken as prisoners or slaves. There is nothing to rebuild. If you ever are mayor of town again, in the foreseeable future, here's some friendly advice: play to your strengths. See you next time, mayor.
~ endingName = "BadFight"
->END


==GoodTrick==
You tell the general that you surrender, and that the town shall throw a party in honor of the future victor of this war.
“Interesting… Well, I would be a fool to refuse my men some respite and festivities before a trying battle. We accept your invitation with pleasure.”
You return to your town with the news, after telling him that you must prepare the festival.
You return to your town, and announce your true plan to your villagers: you will wait for the soldiers to be drunk, asleep, seduced and distracted to then slaughter them in their sleep. The reactions are mixed, but ultimately, everyone realizes that this is the only way to keep the town’s integrity, while safeguarding the lives of the people.
The evening rolls in, and with it the army. The night is full of joy: Will’s tavern has rarely been this busy, and ale flows freely out of its taps. The town is colorful, and seems to be laughing with a voice of its own. Until the night grows deeper, and darker. The party dies down, and all those who cannot fight barricade themselves in their houses, and the soldiers of Leirrus fall asleep in the streets, and in the taverns. Suddenly, as if from the shadows, the volunteers exit their hiding places, armed with knives bearing the crest of Sharp’s Handle. 
Then comes the massacre. If any Leirrus soldier survives, they hide well enough that they are not heard of again. The town screams now, instead of laughing. Soon enough, the dawn sets the horizon aflame, and it is time to see the result of your actions.
The town, as well as its inhabitants, is safe. It takes a while to remove the bodies, and clean out the blood, but the gloom of it is soon erased by a great news: Valguard wishes to reward you, and to make Steadville one of the most important cities in the kingdom! The future of Steadville is now assured, Mayor, and that is thanks to your leadership. Congratulations, Mayor.
~ endingName = "GoodTrick"
->END


==MidTrick==
You tell the mayor that you surrender, and that the town shall throw a party in honor of the future victor of this war.
“Interesting… Well, I would be a fool to refuse my men some respite and festivities before a trying battle. We accept your invitation with pleasure.”
You return to your town with the news, after telling him that you must prepare for the festival.
You return to your town, and announce your true plan to your villagers: you will wait for the soldiers to be drunk, asleep, seduced and distracted to slaughter them in their sleep. Oscar and Lorraine’s faces are like stone, and they turn their back to you, to go and hide in their houses and buildings, bringing with them all who would not take part in this atrocity. Adelaine seems reluctant, but will do as ordered, and Will beams in anticipation to see his Inn be useful. 
The evening rolls in, and with it the army. The night is full of joy: Will’s tavern has rarely been this busy, and ale flows freely out of its taps. The town is colorful, and seems to be laughing with a voice of its own. Until the night grows deeper, and darker. The party dies down, and all those who cannot fight barricade themselves in their houses, and the soldiers of Leirrus fall asleep in the streets, and in the taverns. Suddenly, as if from the shadows, the volunteers exit their hiding places, armed with knives bearing the crest of Sharp’s Handle. 
Then comes the massacre. If any Leirrus soldier survives, they hide well enough that they are not heard of again. The town screams now, instead of laughing. Soon enough, the dawn sets the horizon aflame, and it is time to see the result of your actions.
The town, as well as its inhabitants, is safe. But what of its soul? Well, lives are not the only things that die in war. It takes a while to clean all the bodies, and after that, Steadville never truly seems the same again. It stands however, and that is thanks to your leadership. Congratulations, Mayor.
~ endingName = "MidTrick"
->END

==BadTrick==
You tell the mayor that you surrender, and that the town shall throw a party in honor of the future victor of this war. 
“Interesting… But tell me Mayor, do you take me for a fool? I’ve rarely seen a more obvious trap. Well, you may lack honor, but I do not. I will warn you: return to your town, and prepare our defenses. We attack at dawn.
~ endingName = "BadTrick"
{troops >= 50 && morale >= 75: ->GoodFight}
{troops >= 10: ->MidFight | ->BadFight}

==GoodBribe==
“So, you would compromise your honor and ours for the safety of your town? But tell me, what would I stand to gain from this? From what I can tell, all I see is more mouths to feed for Leirrus. ”
You reveal to them just how much they stand to gain.
“Ah. Well, as much as I dislike that kind of compromise, I don’t know that I can ignore such a… display of wealth put at my disposal. Very well, mayor. You have convinced me. Steadville will be safe, we shall endeavor to find another way through the mountains. Once this war is over, I shall see to it that Steadville is officially recognized as an integral part of the Leirrian supremacy. Farewell.”
You return to your town as the army is already starting to depart. You explain the situation to your citizens. Despite some reservations as to being branded traitors, the sight of their hometown safe of any and all harms is enough to sway even the most vengeful hearts. The rest of the war doesn’t concern you any longer. Steadville will stand for generations to come, and that is all thanks to your leadership. Congratulations, mayor.
~ endingName = "GoodTrick"

->END
==MidBribe==
“So, you would compromise your honor and ours for the safety of your town? But tell me, what would I stand to gain from this? From what I can tell, all I see is more mouths to feed for Leirrus. ”
You reveal to them just how much they stand to gain.
“Ah. Well, as much as I dislike that kind of compromise, I don’t know that I can ignore such a… display of wealth put at my disposal. Very well, mayor. You have convinced me. Steadville will be safe, we shall endeavor to find another way through the mountains. Once this war is over, I shall see to it that Steadville is officially recognized as an integral part of Leirrian supremacy. Farewell.”
You return to your town as the army is already starting to depart. You explain the situation to your citizens. Many are unhappy with your choice, and those with the most vengeful hearts leave town for Valguard’s capital, chief among them Adelaine, leaving your town without a smithy. It is difficult, seeing so many friendly faces leave our hometown forever, but you remember that they have this choice precisely because you made that tough call. Steadville will stand for generations to come. Congratulations, Mayor.
~ endingName = "MidTrick"
->END

==BadBribe==
“I’m afraid, dear Mayor, that the honor of Leirrus cannot be bought quite so easily. If you had been just slightly more generous perhaps. But not with this. I suggest you either flee or prepare your defenses. We attack at dawn.”
You return to Steadville, to face the grave faces of your citizens. You announce the news: you tried to avoid it, but the battle will happen. You hear some sighs, some cries, and when you look in your citizens eyes, you see only quiet resignation. 
~ endingName = "BadTrick"

{troops >= 50 && morale >= 75: ->GoodFight}
{troops >= 10: ->MidFight | ->BadFight}
