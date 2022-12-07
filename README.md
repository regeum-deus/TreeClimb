# TreeClimb
The TreeClimb is an interperated programming language for making text adventure games

--INSTALLATION AND USE--
  just download all of the files in this repository and open your script with branchinterpreter.exe
  files are names as so "filename.branch"

--EXAMPLE CODE--
  script.branch:
    branch root root
    trunk oak hello_world! root
    trunk birch continue[y/n] root
    branch continued y root
    trunk oak good_job! continued
    end continued
    branch didnt n root
    trunk oak I_dont_like_you! didnt
    end didnt
    trunk spruce + root
    end root

  the first line "branch root root" creates a new branch called root (your first branch must always be called root) and root always seeds itself
  "trunk oak hello_world! root" trunk tells the interpereter that we are doing a command there are four types of trunk:
    oak: prints to the screen
    birch: takes input after printing some text
    spruce: just a press enter to continue prompt
    null: passes its input straight to the output stack
   
