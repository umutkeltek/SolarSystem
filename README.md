Hello all,

This project is aiming to create a solar system simulation based on the real mass, distance, and diameters of celestials. Since there is a vast distance and diameter difference between the sun and other planets, the planet's diameters have been increased tremendously. 

There is a game object called "Tour Counter" inside the hierarchy which you may see the tour count completed around the sun. 

There is a child game object called "Mesh" under the planets. Rotation around the planet's axis has been implemented by "Rotate Around Own Axis" script under the "Mesh". The desired rotation rate could be set from there. Right now, every planet has a fixed rotation rate of 20 degrees.

Basically, the sun is pulling planets towards itself with force. To oppose the pulling force, every planet has its own initial velocity to create a centrifugal force against that force, so planets could rotate around the sun without getting pulled. 

Any tips or questions will be appreciated.

- Planets are rotating around their own axis.
- Planets are rotating around the sun.
- Everything is simulated by Newton's law of universal gravitation
- TourCounter object has serializable fields which is showing the count of completed tour by specific planet.
