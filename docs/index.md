# Deal With The Devil

By Alia & Ons

## Alia's Documentation

### First Stage
For this stage of the project I created simple models in maya. I sent them to Ons, we agreed I would work on the slot machine and the interactions of the second layer. She would work on the first layer. So we worked separately on different scenes for this stage of the project. 
With regards to layer 2, I had to create the animations of the letters spinning. This was very tedious to make sure that they spun in the right direction depending on which turn. I saved each animation for each wheel and saved them onto a manager script that would take care of the animations. I placed 4 different Quads as part of the machine that would be enabled(show) depending on which sequence of coins would drop. A collider was placed in a money box that would trigger the animation on the slot machine when the coin(activated by gravity) would drop into the money box. There were some problems with this when it came to attaching the hand controls in VR. I initially used a mousedown function to click on the coins so that they drop into the box. I didn't know what problems would come with this when attaching controllers such as being too close to the box could trigger animation to happen and several would play at the same time and the slot machine would ultimately look like its not working and is stuck, a problem also I believe when using the Invoke function I found that would delay a process for a few seconds. To be quite honest, scripting is not a strength of mine so I searched possible ways of doing this on some forums regarding enabling and disabling game objects during a trigger so I just played around with the code until it worked and didn't really understand the mechanics behind it that well. So I ran into a lot of problems when using the code in VR. There probably was a better way to do it if I could do it a second time. 
Video of First phase of slot machine: [link to video]( https://youtu.be/j9O1qaUJf5k)

### Second Stage
The second stage was adding the locomotion. I ended up doing it but for some reason when I did it clicking on the floor would result in the view being lower than it should be.  This may have had something to do with the scale. However, we just ended up having to delete the locomotion done on my scene when importing it and meshing it with Ons’. She managed to re-do it and it worked. At the start all the coins worked when dropping it into the money box. After meshing it with Ons’  scene I believe some of the things that were enabled became disabled. We tried to figure it out together but kept getting stuck so with some extra help we managed to get it working in one unity project.

![This is an image](alia1.jpg)
![This is an image](alia2.png)

### Final Stage: User testing
At this point Ons and I worked together to identify problems when user testing back and forth and made discussions on changes that should be made. I created the final touches of the models used for the user interface like the arrows, text, and aunt model. I also created the sound used for the project both the voice of Satan and the Aunt. Ons worked on putting the elements of the last layer together.

## Ons' Documentation
### Process
I first started working on the intro layer. After importing the scene model Alia made, the first thing I decided to do was create a dissolve effect (or a reverse dissolve?) for the paper to appear. I followed a tutorial on Shaders to be able to do this. It was done using ‘Simple Noise’ and ‘Add’ nodes that were connected to the alpha clip threshold, along with other things to make the border a glowing orange-red color as well.

![This is an image](ons1.png)
![This is an image](ons2.png)

Once the animation was done, I just added a script for it that incorporates a coroutine which basically enables the animation to start after some waiting time. A lot of other functionalities are added to this same script later for the fingerprint stamping.
The next thing I worked on was the fire which was achieved using a particle system. The script for this was pretty straight forward (disregarding the simple mistake I made that took us several days to figure out haha sorry), it just contains a coroutine that has some waiting time after which the fire starts and some active time after which the fire is turned off, at which stage the document is then also set to appear.

![This is an image](ons3.png)

Some rescaling had to be done at this point as well, because we realized as we were testing these first few functionalities that the scale of the models was way too big compared to a regular person.
Then I moved on to stamping the fingerprint. To do this, I followed the interactions lab to make a slightly transparent bloody fingerprint follow the ray cast on the document. However, upon selection, its position would be fixed and its opacity will be turned all the way up to create a stamping effect. Some boolean flags were used here to ensure that these actions weren’t possible before the document fully appears, etc…
After the stamping is done, the XR rig is triggered to move down to the first layer of hell through using the move towards function and an empty game object containing the destination position.
All of this I believe was done through functions that would trigger coroutines.
After both Alia and I mostly finished these first two scenes (and after a lot of debugging with Professor (thank you!)), we tried merging them together. As Alia already mentioned, some things stopped working correctly and had to fixed, and I also had to re-do the navigation.
I also took the time to design a reticle by following a tutorial on YouTube that used both a shader and a particle system.

![This is an image](ons4.png)

At this point, I also decided it was time to fix the visuals for the interactions and make everything work smoother. So I added the left and right hand controller visuals. I kept the left hand as a ray cast interactor, and I made the right hand a direct one. I set all the teleportation areas, and all the layers and tags, and then we were finally ready to move on to the next layer of hell.
I set up the same XR Rig drop after the final coin in Alia’s scene, and we kept the final layer pretty simple. You have two levers and you have to choose wisely. 

![This is an image](ons5.png)

There is a small hint on how you can figure out which lever is the correct one. The one on your left, you have to slide down meaning it will take you to the last layer of hell where you’ll be stuck. The one on the right you have to slide forward/up representing the fact that you will be taken up to the real world again after hearing the secret. To do this, I just added an if condition inside the OnSelectExited function already existing in the LinearFixture script. It checks if the lever position matches the end position, and if so starts the same coroutine I have been using to move the XR Rig.
Next, I just added the audio files on unity as audio sources, and I used Play() and Stop() in the scripts to trigger them when needed.
The last thing I did was just trying to make the scene look better, by moving stuff around, adding materials, colors, walls around the layers, etc..
The last scene you will be taken down to if you choose the wrong lever is just fire surrounding you. Also, the colors of the layers are supposed to be getting more red as you move down but I’m not sure if that ended up being clear or not.

![This is an image](ons6.png)

### Things I would have liked to add:

1.I definitely believe that more storytelling components would have made the project a lot cooler
2.Making the aunt in the “Choose wisely” layer a 3D figure that hovers up and down to give off a floating effect would have been nice, as well as making it clear that the figure is indeed your aunt.
3.Hiding the coins better around the space in the first layer of hell to make it more challenging would have possibly made the experience more immersive.

Overall, I’m happy with what we were able to accomplish in the amount of time we had, and I’m glad I was pushed to learn more about unity and scripting through this project. I’m very excited to make a more elaborate environment in Project 3.


