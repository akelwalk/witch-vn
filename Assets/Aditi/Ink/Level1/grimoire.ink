INCLUDE ./globals.ink

->knot0
===knot0====
{answered_riddle: -> knot2| -> knot1}

===knot1===
That's my grimoire! They took it when the King imprisoned me. #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
->END

===knot2===
I see a stool over there. Maybe I could cause a distraction...#speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
+ [Maybe Later]
    ->END
+ [Combustion Spell!]
    The stool lit on fire. #speaker: #sfx:spell
    ->knot3
    
===knot3===
~distraction = true
Oh my gods! What is happening??? #speaker:Sphinx #portraitSortingOrder:-3
Sphinx went to examine the stool and put out the fire. #speaker:  #portrait: #clearEndPortrait:true
->END