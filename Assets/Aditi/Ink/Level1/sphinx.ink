INCLUDE ./globals.ink

-> knot0

===knot0====
{answered_riddle: -> knot4| -> knot1}

===knot1===
The Sphinx is guarding your cell. She looks bored. #speaker: #portrait:sphinx_neutral
+ [Nevermind]
    I'd rather not bother her. #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
    -> END
+ [Call her over]
    -> knot2

===knot2===
No talking, please! #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
... #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
Aren't you a Sphinx?
What's it to you? #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
Aren’t you guys supposed to, like, tell riddles or something? #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
Only on our time off, apparently… #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
[Sounds like she doesn’t like the King much either...] #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
I’d like to hear a riddle! #speaker:Altheia #portrait:altheia_neutral
Really?! #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
Of course! Except I want something if I answer correctly. #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
Well, I’m really not supposed to anyway. What do you want? #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
Just my book over there. For reading. You know how boring it gets in here… #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
If I don’t answer correctly, you can keep asking me riddles until your shift is up, and I won’t get anything for answering right. #speaker:Altheia #portrait:altheia_neutral
What do you say? You look like you ask a tough riddle; I’m sure I won’t get it right the first time.
I am pretty incredible … It seems harmless enough. Okay, it’s a deal! Are you ready? #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
Do your worst. #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
Round she is, yet flat as a board, #speaker:Sphinx #portrait:sphinx_neutral #italics:true #portraitSortingOrder:-3
Altar of the Lupine Lords,
Jewel on black velvet, pearl in the sea,
Unchanged but e’erchanging, eternally.
... #speaker:Altheia #portrait:altheia_neutral #italics:false #portraitSortingOrder:-1
+ [The moon?]
    ~answered_riddle = true //setting the flag for answering riddle correctly
    ... #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
    ->knot3
+ [A coin?]
    Ooh! No. Better luck next time! #speaker:Sphinx #portrait:sphinx_neutral #gameover:true #portraitSortingOrder:-3
    -> END 
+ [I have no idea.]
    Really?? You didn’t even try! #speaker:Sphinx #portrait:sphinx_neutral #gameover:true #portraitSortingOrder:-3
    -> END 
    
===knot3===
Unfortunately, that’s correct. Here’s your book. UGH! #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
You have received your Grimoire! #speaker: 
I should try escaping now that I have my powers back. #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
->END

===knot4===
She is still watching you. #speaker: 
We can still play riddles if you want! #speaker:Sphinx #portrait:sphinx_neutral #portraitSortingOrder:-3
No thanks, I’ve got my book now. #speaker:Altheia #portrait:altheia_neutral #portraitSortingOrder:-1
->END


