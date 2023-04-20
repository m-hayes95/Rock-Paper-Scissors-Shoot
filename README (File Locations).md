Rock-Paper-Scissors-Shoot - Trimester 2 game project 003 Structured Game Dev & 004 Game Dynamics - 

Referenced File locations for Data structures, patterns and enemy A.I:

003 STRUCTURED GAME DEV
+ State Machines: 
   + Enemy > EnemyAI, 
   + UI Scripts > NewHeartsVisual.
+ Singletons: 
   + Audio > GameplayMusic, 
   + Player > PlayerHealth & VectorDistance, 
   + Scripts > CameraShake & HighScoreManager.
+ Data Structure (Arrays):
   + Tiles > RandomTileGenerator.
+ Data Structure (Lists): 
   + Enemy > EnemyAI - (moves), 
   + Tiles > TilePrefabPool, 
   + UI Scripts > NewHeartsVisual & OptionsMenu.
+ New Controller Input System: 
   + Player > PlayerController & PlayerSpawnerController, 
   + UI Scripts > PauseMenu.S
+ Object Pool (NOT USED - Tried to use it as a parameter to spawn random tiles from):
   + Tiles > TilePrefabPool.
+ Coroutine, IEnumerator: 
   + Auido > GameplayMusic, 
   + Scripts > GameManager.

004 GAME DYNAMICS
+ Procedural Generation: 
   + Tiles > RandomTileLightSpawner &  RandomTileGenerator.
+ A.I Behaviour (using state machine): 
   + Enemy > EnemyAI.

