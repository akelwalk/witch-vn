->knot1

===knot1===
There's another castle guard. He's already spotted you. #speaker: 
Huh? #speaker:Troll #portrait:troll_neutral
[Uh oh...] #speaker:Altheia #portrait:altheia_neutral
What are you, then? #speaker:Troll #portrait:troll_neutral
Uhhh... a friend of the king? #speaker:Altheia #portrait:altheia_neutral
You do not look like a friend of King Highborn. Much too dirty, you is. #speaker:Troll #portrait:troll_neutral
No, methinks you is an escaped prisoner from the dungeons! Come to think of it, I remember my king banishing a pesky little witch who wouldn’t do as it was told.
[Busted...] Alright, you've got me. #speaker:Altheia #portrait:altheia_neutral
Come here, you little-- #speaker:Troll #portrait:troll_neutral
What should I do? #speaker:Altheia #portrait:altheia_neutral
+ [Give Up]
    Troll swings his club at you, and you feel your consciousness slowly fade away. #speaker:Troll #gameover:true
    -> END
+ [Persuade]
    ->knot2

===knot2==
Let me pass, and I won’t have to hurt you. #speaker:Altheia #portrait:altheia_neutral
Tiny witch hurt Troll? Ha ha ha! #speaker:Troll #portrait:troll_neutral
Hey! I’m powerful!! #speaker:Altheia #portrait:altheia_neutral
[I must show him who's boss. My pride's at stake here.]
+ [Beat Him Up]
    I bet you can't take these FISTS!!! #speaker:Altheia #portrait:altheia_neutral
    WHAM! #speaker: 
    ...Owww that huuurts. #speaker:Altheia #portrait:altheia_neutral
    Puny witch. You die now! #speaker:Troll #portrait:troll_neutral #gameover:true
    ->END
+ [Cast Spell]
    ->knot3

===knot3===
[What should I cast?]
+ [Light Spell]
    You cast light spell, and all the lights in the room suddenly go out! You can tell where the Troll is by his heavy footsteps, allowing you to sneak past him and enter the throne room. #speaker: #sfx:spell
    CURSE TINY WITCH-BUUUUG!!! #speaker:Troll #portrait:troll_neutral #transition:Level 3
    ->END
+ [Combustion Spell]
    You cast combustion spell on the Troll! #speaker: #sfx:spell
    OWWIEEEEEEE!!! #speaker:Troll #portrait:troll_neutral
    Uh Oh! The Troll seems more annoyed than injured. #speaker: 
    Stupid insect! Troll will crush you like a bug! #speaker:Troll #portrait:troll_neutral
    ->knot3
+ [Unlocking Spell]
    There's nothing here to unlock. #speaker: 
    ->knot3

