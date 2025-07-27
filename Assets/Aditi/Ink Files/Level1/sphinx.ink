INCLUDE ./globals.ink

-> knot0

===knot0====
{answered_riddle: -> knot4| -> knot1}

===knot1===
The Sphinx is guarding your cell. She looks bored. #speaker: #portrait:sphinx_neutral
+ [Nevermind]
    I'd rather not bother her. #speaker:Altheia
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
    ~answered_riddle = true //setting the flag for answering riddle correctly
    ... #speaker:Sphinx
    ->knot3
+ [A coin?]
    Ooh! No. Better luck next time! #speaker:Sphinx
    -> END //gameover
+ [I have no idea.]
    Really?? You didn’t even try! #speaker:Sphinx
    -> END //gameover
    
===knot3===
Unfortunately, that’s correct. Here’s your book. UGH! #speaker:Sphinx
You have received your Grimoire! #speaker: 
I should try escaping now that I have my powers back. #speaker:Altheia
->END

===knot4===
She is still watching you. #speaker: 
We can still play riddles if you want! #speaker:Sphinx
No thanks, I’ve got my book now. #speaker:Altheia
->END


