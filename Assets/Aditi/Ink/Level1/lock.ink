INCLUDE ./globals.ink

-> knot0

===knot0===
{answered_riddle: {unlocked: -> knot3 | ->knot4} | -> knot1 }

===knot1=== //havent gotten spellbook
It's locked. If only I could cast my unlocking spell... #speaker:Altheia #portrait:altheia_neutral
->END

===knot2=== //didn't do distraction
Hey, what are you doing! Get back in there! And give me that book! #speaker:Sphinx #portrait:sphinx_neutral #gameover:true
    ->END 

===knot3=== //can escape
I'm free! Should I make my escape? #speaker:Altheia #portrait:altheia_neutral
+ [No]
    I want to take one last look at my prison. #speaker:Altheia #portrait:altheia_neutral #clearEndPortrait:true
    ->END
+ [Yes]
    Finally! I can't wait to see the look on the King's face once he knows I've gone missing. #speaker:Altheia #portrait:altheia_neutral #transition:Level 2
->END

===knot4=== //deciding to unlock door or not
Use unlocking spell? #speaker: 
+ [Maybe Later]
->END
+ [Let's get out of here!]
~unlocked = true
The door unlocks and opens. #speaker: #sfx:spell
{distraction: -> knot3 | -> knot2}
->END