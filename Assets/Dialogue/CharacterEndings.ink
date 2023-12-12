VAR AdelaineMorale = 50
VAR LorraineMorale = 50
VAR OscarMorale = 50
VAR WillMorale = 50
VAR RoeMorale = 50

VAR BadFightEnding = true


{
- BadFightEnding == true:

->END

- else:

{
- OscarMorale >= 70:
   He wouldn’t have liked any way you handled the army but with seasons passing you can notice a sense of respect between the two of you. Oscar continued to fish for the town and even found an apprentice, Baker Mary’s son Jack. He’s learned to sit quietly with him on the boat, fish masterfully and it’s been said that Jack even made Oscar laugh out loud. Oscar and Lorraine have begun talking and it’s created some buzz among the townsfolk. Oscar seems quite happy despite how hard he is to read.
   
   - OscarMorale <= 70 && OscarMorale >= 30:
   He still gets up every morning to fish. He’ll go a couple weeks without talking to anyone sometimes. He’s found a park bench in the town square where he eats his lunch everyday. He doesn’t start any conversation but he feels a little more a part of the town now. Oscar may soften up as time passes but he’ll never really change, and that's for the best as he prefers a quiet life.
   
   - else: 
       Oscar still gets up every morning to fish. No one has heard him speak in a few months, he doesn’t come to your office to check in anymore. If there is one thing that everybody knows about Oscar, it is that he has seen some things but now we know he just might not recover from it.
   }
   
   {
   - AdelaineMorale >= 70:
      In the end she’s just happy that Steadville is still standing, and Adelaine continues to blacksmith for the town. Her and Will became better friends, they still have lunch everyday. Adelaine has begun taking on more duties in town, but has started confiding in you that she may want to travel throughout Silmara. Her and Will have even loosely planned a trip through the Myria planes. Of course if Lorraine found out that Adelaine might leave she’d flip out so Adelaine is keeping it on the down low.
   
   
   
   - AdelaineMorale <= 70 && AdelaineMorale >= 30:
   Adelaine’s been closing shop up early these days, she’s been out helping around the town. She’s been less productive recently but not noticeably, she doesn’t care as much anymore but almost in a good way. She seems to realize there are other aspects of life that matter and she’s even been spending more time at Inn talking with some friends.
   
   - else:
       
    Adelaine’s been closing shop up early these days, no one knows where she goes. Her productivity has been low and she’s been quite rude, especially to newcomers. Lorraine has been checking in every day but rarely gets any conversation out of her. She’s struggling and she’s much too young to be left alone. Hopefully with more time she’ll feel better.
   
   
   }
   
   {
    - RoeMorale >= 70:
   Roe has been in the mine as always and has dug deeper and deeper, one day they came back with a glowing purple stone that they called Steadium which ironically is incredibly unstable and blows up on contact with moon light. On a lighter note because of their discovery of Steadium they have also been attributed the invention of fireworks. Which has been brightening the evenings of all the parties that Will has been hosting.
   
    - RoeMorale <= 70 && RoeMorale >= 30: 
   Roe has been continuing to find the planet's core, they have expanded their mine miles deep. They asked you to come with them to the bottom of the mine one day, and you walked with them for 3 hours before you realized you weren’t anywhere close to the end. After that day you realized why Roe has been gone for days every time they enter the mine.
   
    - else:
    Roe has been acting unusual and by that, meaning surprisingly usual for someone having a tough time. They’ve isolated themself, in the mine of course. Rarely seen now, Adelaine has said that they are doing okay and just need some time alone. Roe has always been an enigma to you so you give them the benefit of the doubt and give them some space.
   
   }
   
    {
    - WillMorale >= 70:
   Despite his rocky start in the town Will has really caught his stride as time goes on. He’s brought a nightlife to the town that it has never had before. Although Lorraine disapproved of him at first she’s grown a liking to him because he is the reason for such high spirited youths in the town. He’s also brought many traditions from the capital to Steadville, the parties, the decorations. Will has even asked to take on party planning entirely, this initiative has also been a cause of Lorraine's happiness with him.
   
    - WillMorale <= 70 && WillMorale >= 30: 
   Will has been okay, he still smiles at you when you pass each other. The Inn has been steady recently, Will always has something to do while leaving enough time to rest. It’s easy to work as hard as he does when your friends hangout with you at your bar as you work. He’s gotten quite a few employees over the past months as word around town is that he’s a great boss, and apparently pays quite well.
   
    - else:
       Will has been okay, he still smiles to you when you pass each other and makes small talk with everyone at his Inn. Unfortunately you fear that small talk is the only talk he’s making. You used to see him bring lunch to Adelaine, he’d knock on her door and ask to eat with her and sometimes she’d even let him. But lately he'll leave food at her doorstep, knock and walk away, sometimes Adelaine won’t even pick up the food. 
   
   }
   
{
    - LorraineMorale >= 70:
       As she’s gotten older she hasn’t been as spry as she used to, her children have asked her to stop working out in the fields and move to more of a management position. At first she was quite resistant but she remembered what it meant to relax for the first time in decades when Oscaar took her out on a short boat ride. Since then she’s been allowing her children; mainly her eldest daughter Lucy to take control of the farm and the shop. Lorraine still watches over the town with the eye of a hawk but now she’s spending much more time having fun rather than making sure others are having fun
    
    - LorraineMorale <= 70 && LorraineMorale >= 30: 
   
Lorraine Florrace
Her routine has stayed the same, she wakes up early, watches the sunrise and then begins her work in the field. She then spends the rest of the day strolling the town and talking to people, as always she is the heart of the town but she’s getting old. Someday Lorraine will have to cut back on her work, and you think the day might be sooner rather than later.

    - else:
       
    Her routine has stayed the same, she wakes up early, watches the sunrise and then begins her work in the field. She then spends the rest of the day strolling the town and talking to people, as always she is the heart of the town but you’ve noticed something is off, She’s not quite the same. It’s not a limp in her step or a missing smile, it’s something deeper, a sadness that you don’t think you have the power to solve. But Lorraine is tough, she will be okay.
   
   }

}



