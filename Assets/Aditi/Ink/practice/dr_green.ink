Hello there! #speaker:Dr. Green #portrait:green_neutral
->main

===main===
How are you feeling today?
+ [Happy]
    That makes me feel happy as well! #portrait:none
+ [Sad]
    Oh, well that makes me sad too. #portrait:green_sad
- Don't trust him, he's not a real doctor! #speaker:Ms. Yellow #portrait:sphinx_neutral

Well, do you have any more questions?#speaker: Dr. Green #portrait:green_neutral
+ [Yes]
    -> main
+ [No]
    Goodbye then!
    -> END