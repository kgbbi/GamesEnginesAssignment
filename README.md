# Game Engines Assignment
 
# Contributers
- Alex Hurduc <C15344251@mydit.ie>

# Licence & Copyright

© Alex Hurduc, Student Number: C15344251, Dublin Institute of Technology,CMPU4030 Games Engines 1, 2018

# Proposal

For My Assignment I am hoping to make a wormhole visual effect.
![Wormhole1](https://dw8stlw9qt0iz.cloudfront.net/r25sg1lOA7WS_me9ltpM9kQGBQc=/fit-in/800x450/filters:format(jpeg):quality(75)/curiosity-data.s3.amazonaws.com/images/content/landscape/standard/cd821afb-8917-4b69-e892-545c22d1dbcd.png)

![Wormhole2](https://news.bitcoin.com/wp-content/uploads/2018/08/WH.jpg)

[Example Video](https://youtu.be/2oUNc_9NFvU)

The wormhole will have different colours and visual effects as it goes further on which i hope to be procedurally generated.
The goal is to have a really visually pleasing effect that I believe would have a cool sci-fi vibe.

# What The Project Does

It aims to provide a visual experince that is pleaseant and gives off the impression of being in a wormhole.

# How It Works

There are 4 steps that I did when doing this project.
Step 1:  Create a torus, This was the building block of the wormhole and was how I saw through research that it was one of the best methods to create such a tunnel.
Step 2:  Combine multiple random torus tunnels together. Because the wormhole effect makes for random angles, this means that there must be multiple wormhole segments.
Step 3:  Camera movement for the user in order to be able to get a more immersive effect. Done by setting up horizontal left right input.
Step 4:  I was hoping to have random generated blocks that I could add to the project that would of have been affected by sound however I have not managed to get that part working yet.

A wormhole has many segments which can be derived from a partial circle which in 3D is called a torus. A torus has two radiuses. One is radius of the wormholes diameter and the second is the radius of the curve in a given direction.
This can be seen below.



![Torus](https://i.ytimg.com/vi/viBUNh82YEc/hqdefault.jpg)



In order to make the wormhole outside surface I used a mesh. I then proceeded to segment that wormhole into quads.
A torus can be defined using the following function.
x = (R + r cos v) cos u
y = (R + r cos v) sin u
z = r cos v
 
 r = radius of tunnel. 
 R = radius of the curve.
 u = angle along the curve denoted in radians so in the 0–2π.
 v = value of angle along the tunnell.
 
 The construction of  the mesh was set to when the object awakens which requires its triangles and vertices to be set.To do this I triangulated the torus by giving each quad in the tunnell four vertices.
 I started with the first diameter of quads and got two vertices: Vertex A and Vertex B which is set along the u axis from the torus function. Then I increment one along v and grab the next four vertices. 
 This is repeated until the entire torus is meshed .Every increment the previous and new points are assigned to the current vertices if that segment.
 Next the triangles are inititalized which gives each quad two triangles containing six indices. We run a function that assigns those the whole way around and thats how the entire torus is now covered.
 Because a wormhole is not an entire torus I need to create only segments of a torus and not a full one. Therefore I can instantiate many chidlren of a partial torus that when aliged with eachother and assigned a random relativee rotation they can have multiple angles in which a user cant predict which way its going to turn.
 Because moving in a straight line with no control is boring. It was ideal to convert the delta into a rotation in order to update the system's orientation. Each tunnell segment shifts through its array, align the next pipe with the origin, and reset its position.
It keeps track of the world rotation and update it when going into a new tunnel segment by running the function in both Start and Update.

## Development

I really enjoyed working with Unity, however It was really hard for me to maintain momentum throughtout the semester with it. I felt like the speed was too fast for me and that was probably only because I have never used Unity
before in college or in my personal time. However there are alot of tutorials, forums and information online that helped a great deal in helping me understand and develop this project. There were mainly tutorials that I researched from building meshes , redering , random generation , object generation , audio effects etc. 
Alltogether using all this information I was able to mesh together myself a decent project that I would like to keep developing in my free time as a hobby especially now that the semester is over and I finally have some free time to not be stressed out on
other modules.One of my biggest regrets in doing this project is that I couldnt add all the features I wanted in time which is a real shame. The audio manimulation of the Objects i tried for an entire day to work out and got nowhere. 
This is simply due to me still learning Unity and how it all works together to create a work of art.
Overall it was enjoyable and was definitely the most fun module of the semester even though it was one of the hardest for me to be on par with the rest of the class.

##Video

[Video of my project](https://youtu.be/J0fEfNex4LA)
[Video of my project](https://youtu.be/MXm9OmzRe2o)
[For entertainment purposes only](https://youtu.be/ofe1ErfBfK4)
