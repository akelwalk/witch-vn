-> knot1

===knot1===
The Sphinx is guarding your cell. She looks bored. #speaker: #portrait:sphinx_neutral
+ [Nevermind]
    <i>I'd rather not bother her.</i> #speaker:Altheia
    -> END
+ [Call her over]
    -> knot2

===knot2===
No talking, please! #speaker:Sphinx 
... #speaker:Altheia
Aren't you a Sphinx?
What's it to you? #speaker:Sphinx 
Aren’t you guys supposed to, like, tell riddles or something? #speaker:Altheia
Only on our time off, apparently… #speaker:Sphinx
[Sounds like she doesn’t like the King much either...] #speaker:Altheia
I’d like to hear a riddle! #speaker:Altheia
Really?! #speaker:Sphinx
Of course! Except I want something if I answer correctly. #speaker:Altheia
Well, I’m really not supposed to anyway. What do you want? #speaker:Sphinx
Just my book over there. For reading. You know how boring it gets in here… #speaker:Altheia
If I don’t answer correctly, you can keep asking me riddles until your shift is up, and I won’t get anything for answering right. #speaker:Altheia
What do you say? You look like you ask a tough riddle; I’m sure I won’t get it right the first time.
I am pretty incredible … It seems harmless enough. Okay, it’s a deal! Are you ready? #speaker:Sphinx
Do your worst. #speaker:Altheia
Round she is, yet flat as a board, #speaker:Sphinx #italics:true
Altar of the Lupine Lords,
Jewel on black velvet, pearl in the sea,
Unchanged but e’erchanging, eternally.
... #speaker:Altheia #italics:false
+ [The moon?]
    ... #speaker:Sphinx
    ->knot3
+ [A coin?]
    Ooh! No. Better luck next time! #speaker:Sphinx
    -> END //bad ending
+ [I have no idea.]
    Really?? You didn’t even try! #speaker:Sphinx
    -> END //bad ending? have some sort of text for that
    
===knot3===
Unfortunately, that’s correct. Here’s your book. UGH! #speaker:Sphinx
You have received your grimoire! #speaker: 

->END


