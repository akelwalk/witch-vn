INCLUDE ../Level1/globals.ink

{interacted_king: ->knot2 | ->knot1}

===knot1===
You? What are you doing out of my dungeons? #speaker:King #portrait:king_neutral
You couldn’t keep me in that cell any more than you could keep me from doing what was right when I worked for you. #speaker:Altheia #portrait:altheia_neutral
Minions should do as they are told. Not listen to their own misguided moral compasses first. #speaker:King #portrait:king_neutral
I can only assume you have some business with me since you had the impudence to show up here. Go on with it.
~interacted_king = true
->knot2

===knot2===
Should I cast a spell? #speaker:Altheia #portrait:altheia_neutral
+ [Not Yet]
    There's something I want to check first. #speaker:Altheia #portrait:altheia_neutral
    ->END
+ [Yes]
    ->spell 

===spell===
What should I cast? #speaker:Altheia #portrait:altheia_neutral
+ [Light Spell]
    There's nothing here to light. #speaker: 
    ->spell
+ [Combustion Spell]
    ->knot4
+ [Unlocking Spell]
    ->knot3

===knot3===
The window unlocks and opens! You hear a voice coming from the other side of it. #speaker: #sfx:spell
Wait! #speaker:??? #portrait: 
Sphinx! What are you doing here? You should be guarding the dungeons! #speaker:King #portrait:king_neutral
I realized that my real enemy isn’t someone who was wrongfully imprisoned and wants to be free. It’s the villain who restricted both our freedoms in the first place! #speaker:Sphinx #portrait:sphinx_neutral
Altheia, let’s defeat him together!
+ [Fight Him!]
    Absolutely. It's time for some PAYBACK! #speaker:Altheia #portrait:altheia_neutral
    YES! #speaker:Sphinx #portrait:sphinx_neutral
    You surround the king. Sphinx grabs him with her sharp talons and lifts him high into the air using her powerful wings. She drops him, and just as he hits the ground, you cast your combustion spell. #speaker: #portrait:king_neutral
    The smoke clears, and you both see that the king is barely concious, having cast a defensive spell at the last moment.
    Sphinx knocks him out cold and throws him in prison.
    We did it! What do you say we run this kingdom the way it was meant to be led? #speaker:Altheia #portrait:altheia_neutral
    I would love to. #speaker:Sphinx #portrait:sphinx_neutral
    You both decide to run the kingdom equally and fairly. Under your rule, magic research thrives and the kingdom supports powerful mages instead of shunning them to the dark corners of society. #speaker: #portrait:altheia_neutral
    Sphinx, having a fondness for riddles, creates a civil service examination that awards ordinary citizens government positions based on their intellect and character. #speaker: #portrait:sphinx_neutral
    This new system of government protects people and creatures of all kinds, winning the favor and respect of the public. #speaker: #portrait: //ending
    ->END
+ [Escape!]
    He's not worth it. Let's escape together! #speaker:Altheia #portrait:altheia_neutral
    Well, I can't beat him without you, so... let's get out of here! #speaker:Sphinx #portrait:sphinx_neutral
    You both escape from the castle and live a long and happy life together far from the King's empire. #speaker: #portrait: //ending 
    ->END
    
===knot4===
The only thing misguided about my values was that I didn’t decide to kill you the first time around. #speaker:Altheia #portrait:altheia_neutral
You’re evil. And now I’m gonna take everything from you, just like you did to me and countless others.
You fire a combustion spell in the King's direction. #speaker: #sfx:spell
Right before the spell hits, the King raises his hand and deflects it! #portrait:king_neutral
HA ha ha. You think you can defeat me? There’s a reason you were in that cell in the first place. #speaker:King #portrait:king_neutral
I-I'm just testing the waters. You haven't seen anything yet. #speaker:Altheia #portrait:altheia_neutral
I was too lenient with your impertinence before. The only way to get rid of a nuisance is to do it yourself.... #speaker:King #portrait:king_neutral
The King starts powering up an attack. You can see supercharged energy coalesce at his glowing fingertips.#speaker: 
->knot5

===knot5===
It will be bad if he finishes casting that spell. I need to think of something quickly. #speaker:Altheia #portrait:altheia_neutral
+ [Tell a joke]
    Why was the witch's broom late? #speaker:Altheia #portrait:altheia_neutral
    ... #speaker:King #portrait:king_neutral
    Because it overswept. #speaker:Altheia #portrait:altheia_neutral
    ...Are those your last words? You must have accepted your fate if you've resorted to speaking nonsense. #speaker:King #portrait:king_neutral
    Because of your interruption, the bewildered King subconsciously slows down his casting speed.#speaker: 
    Heh. I've got way more jokes up my sleeve to go down without a fight. #speaker:Altheia #portrait:altheia_neutral
    Such insol- #speaker:King #portrait:king_neutral
    What do you call it when a witch has hope for the future? #speaker:Altheia #portrait:altheia_neutral
    The King's looks at you with confusion. #speaker: #portrait:king_neutral
    Witchful thinking. #speaker:Altheia #portrait:altheia_neutral
    The King's shoulders start to tremble and his face starts to twitch. The energy concentrated in his hand is unraveling! #speaker: #portrait:king_neutral
    W-what are you doing to me? Cease at once! #speaker:King #portrait:king_neutral
    You grin maniacally. It's working! #speaker: #portrait:altheia_neutral
    What happens to witches who break the school rules? #speaker:Altheia #portrait:altheia_neutral
    The King's face turns beet red and his eyes turn bloodshot, screaming a silent protest. #speaker: #portrait:king_neutral
    They get ex-spelled. #speaker:Altheia #portrait:altheia_neutral
    The King's concentration breaks and his spell dissolves into nothing. It looks like he's trying real hard to not laugh. #speaker: #portrait:king_neutral
    Now's my chance! #speaker:Altheia #portrait:altheia_neutral
    + + [Combustion Spell]
        A glowing red magic bullet shoots towards the furious King. He is too disoriented to deflect the spell.
        The spell hits him squarely in the chest, and he catches on fire. His haunting eyes stare daggers at you, cursing you from afar until they burn away too. #speaker: #portrait:king_neutral
        Whew. Never doubt me again. #speaker:Altheia #portrait:altheia_neutral
        // The feeling of taking a life, no matter how despicable, weighs on your conciousness.
        This place gives me bad memories, and I do not want to deal with the aftermath of the King's death. 
        Maybe if I had a friend's support, I would be willing to establish a system of government. I fear falling into the late King's footsteps if I take over the throne alone.
        Altheia escapes the castle and lives out her life peacefully, practicing spells and experimenting with potions in her cottage. #speaker: #portrait: //ending
    ->END
+ [Cast Spell]
    ->spell2
+ [No time. Run!]
    Ugh I can't think of anything. I should make a break for it before it's too late. #speaker:Altheia #portrait:altheia_neutral
    Just as you've made your mind up to run, the King finishes his spell. #speaker: #portrait:king_neutral
    You can run, but you can never escape my clutches. #speaker:King
    You try dodging it but the spell homes in on you and strikes. A harrowing pain floods your senses. #speaker: 
    The King's arrogant face is the last thing you remember. #speaker: #portrait:king_neutral #gameover:true
    ->END
    
===spell2===
What should I cast?
+ [Nevermind]
    Let me think of something else. #speaker:Altheia #portrait:altheia_neutral
    ->knot5
+ [Light Spell]
    The King's fingers are glowing. I can try using this spell to snuff that light out. #speaker:Altheia #portrait:altheia_neutral #sfx:spell
    Your spell dims the room for a second and then fails. #speaker: 
    Clever, but that isn't enough to override my magic.  #speaker:King #portrait:king_neutral
    In the time it took you to cast this spell, the King has finished his. #speaker: 
    His distructive spell shoots towards you. A harrowing pain floods your senses. #speaker: 
    The King's amused face is the last thing you remember. #speaker: #gameover:true
    ->END
+ [Combustion Spell]
    That did not work so great last time. Let's try something else. #speaker:Altheia #portrait:altheia_neutral
    ->spell2
+ [Unlocking Spell]
    The window behind the King unlocks! You hear a voice coming from it, but it's too far away to discern.  #speaker: #sfx:spell
    In the time it took you to cast this spell, the King has finished his. #portrait:king_neutral
    His distructive spell shoots towards you. A harrowing pain floods your senses.
    The King's sneering face is the last thing you remember. #portrait:king_neutral #gameover:true
    ->END
    
