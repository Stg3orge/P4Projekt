GameObject MainCharacter;
GameObject MainCamera;
GameObject Cloud;
GameObject StartSquare;
GameObject Level1Triangle1;
GameObject LifeUIText;
GameObject Level1Trigger1;
GameObject DeathTrigger;
int FrameCount;
bool IsMainCharacterDestoryed;
Vector2 SpawnLocation;
double SpawnLocationX;
double SpawnLocationY;
string LifeString;
int LifeCount;
GameObject Level1Trigger1OnEnterMessage;
void Awake() 
{
MainCharacter = (GameObject) Instantiate(Resources.Load("Prefabs/CharacterPrefab"));
MainCamera = (GameObject) Instantiate(Resources.Load("Prefabs/CameraPrefab"));
Cloud = (GameObject) Instantiate(Resources.Load("Prefabs/SpritePrefab"));
StartSquare = (GameObject) Instantiate(Resources.Load("Prefabs/SquarePrefab"));
Level1Triangle1 = (GameObject) Instantiate(Resources.Load("Prefabs/TrianglePrefab"));
LifeUIText = (GameObject) Instantiate(Resources.Load("Prefabs/UITextPrefab"));
Level1Trigger1 = (GameObject) Instantiate(Resources.Load("Prefabs/TriggerPrefab"));
DeathTrigger = (GameObject) Instantiate(Resources.Load("Prefabs/TriggerPrefab"));
Level1Trigger1OnEnterMessage = (GameObject) Instantiate(Resources.Load("Prefabs/UITextPrefab"));
}
void Start() 
{
FrameCount = 0;
SpawnLocationX = 0.0f;
SpawnLocationY = 0.0f;
SpawnLocation = new Vector2(0.0f, 0.0f);
LifeString = "Life: 3";
LifeCount = 3;
MainCharacter.GetComponent<Character>().Size = new Vector2(1.0f, 0.8f);
MainCharacter.GetComponent<Character>().Location = SpawnLocation;
MainCharacter.GetComponent<Character>().Speed = 7.1f;
MainCharacter.GetComponent<Character>().MoveLeftKey = "A";
MainCharacter.GetComponent<Character>().MoveRightKey = "D";
MainCharacter.GetComponent<Character>().JumpKey = "Space";
MainCharacter.GetComponent<Character>().Alive = true;
MainCharacter.GetComponent<Character>().JumpHeight = 10.5f;
MainCamera.GetComponent<CameraController>().Location = new Vector2(0.0f, 0.0f);
MainCamera.GetComponent<CameraController>().Target = MainCharacter;
MainCamera.GetComponent<CameraController>().DistanceToTarget = 8.3f;
Cloud.GetComponent<SpriteController>().Size = new Vector2(1.5f, 1.5f);
Cloud.GetComponent<SpriteController>().Location = new Vector2(0.0f, 4.0f);
Cloud.GetComponent<SpriteController>().Picture = "Sprites/Cloud";
Cloud.GetComponent<SpriteController>().Visible = true;
Cloud.GetComponent<SpriteController>().Speed = 2.3f;
StartSquare.GetComponent<Square>().Size = new Vector2(10.0f, 1.0f);
StartSquare.GetComponent<Square>().Location = new Vector2(0.0f, -6.0f);
StartSquare.GetComponent<Square>().Picture = "Sprites/Box";
StartSquare.GetComponent<Square>().Visible = true;
Level1Triangle1.GetComponent<Triangle>().Size = new Vector2(1.0f, 1.0f);
Level1Triangle1.GetComponent<Triangle>().Location = new Vector2(10.0f, -6.0f);
Level1Triangle1.GetComponent<Triangle>().Picture = "Sprites/triangle123";
Level1Triangle1.GetComponent<Triangle>().Visible = true;
GameObject Level1Triangle1DeathTrigger;
Level1Triangle1DeathTrigger = (GameObject) Instantiate(Resources.Load("Prefabs/TriggerPrefab"));
Level1Triangle1DeathTrigger.GetComponent<Trigger>().Size = Level1Triangle1.GetComponent<Triangle>().Size;
Level1Triangle1DeathTrigger.GetComponent<Trigger>().Location = Level1Triangle1.GetComponent<Triangle>().Location;
Level1Triangle1DeathTrigger.GetComponent<Trigger>().Enabled = true;
Level1Triangle1DeathTrigger.GetComponent<Trigger>().OnEnter = Lose1LifeOnEnter;
LifeUIText.GetComponent<UIText>().TextSize = 25;
LifeUIText.GetComponent<UIText>().Location = new Vector2(-850.0f, 450.0f);
LifeUIText.GetComponent<UIText>().DisplayText = LifeString;
LifeUIText.GetComponent<UIText>().Visible = true;
LifeUIText.GetComponent<UIText>().TextboxSize = new Vector2(360.0f, 60.0f);
Level1Trigger1.GetComponent<Trigger>().Size = new Vector2(2.0f, 10.0f);
Level1Trigger1.GetComponent<Trigger>().Location = new Vector2(-3.0f, 0.0f);
Level1Trigger1.GetComponent<Trigger>().Enabled = true;
Level1Trigger1.GetComponent<Trigger>().OnEnter = Level1Trigger1OnEnter;
Level1Trigger1.GetComponent<Trigger>().OnExit = Level1Trigger1OnExit;
Level1Trigger1.GetComponent<Trigger>().OnStay = Level1Trigger1OnStay;
DeathTrigger.GetComponent<Trigger>().Size = new Vector2(1.0f, 12.0f);
DeathTrigger.GetComponent<Trigger>().Location = new Vector2(0.0f, -10.5f);
DeathTrigger.GetComponent<Trigger>().Enabled = true;
DeathTrigger.GetComponent<Trigger>().OnEnter = DeathTriggerOnEnter;
}
void Update() 
{
if(MainCharacter.GetComponent<ITouching>().IsTouching == Cloud && MainCharacter.GetComponent<ITouching>().IsTouching == StartSquare) 
{
Debug.Log("MainCharacter touches Cloud xD.");
}
}
void Lose1LifeOnEnter() 
{
LifeCount = LifeCount-1;
}
void DeathTriggerOnEnter() 
{
Destroy(MainCharacter);
}
void Level1Trigger1OnEnter() 
{
Level1Trigger1OnEnterMessage.GetComponent<UIText>().TextSize = 25;
Level1Trigger1OnEnterMessage.GetComponent<UIText>().Location = new Vector2(0.0f, 0.0f);
Level1Trigger1OnEnterMessage.GetComponent<UIText>().DisplayText = "Level 1:";
Level1Trigger1OnEnterMessage.GetComponent<UIText>().Visible = true;
Level1Trigger1OnEnterMessage.GetComponent<UIText>().TextboxSize = new Vector2(160.0f, 30.0f);
}
void Level1Trigger1OnExit() 
{
GameObject message;
message = (GameObject) Instantiate(Resources.Load("Prefabs/UITextPrefab"));
message.GetComponent<UIText>().TextSize = 25;
message.GetComponent<UIText>().Location = new Vector2(0.0f, 800.0f);
message.GetComponent<UIText>().DisplayText = "Level 1: Completed!";
message.GetComponent<UIText>().Visible = true;
message.GetComponent<UIText>().TextboxSize = new Vector2(220.0f, 30.0f);
}
void Level1Trigger1OnStay() 
{
Debug.Log("Level1Trigger1StayFrameCount");
}
int IntegertestMethod() 
{
int i;
i = 5;
return i;
}
bool BooleantestMethod() 
{
bool i;
i = false;
return i;
}
Vector2 PointtestMethod() 
{
Vector2 i;
i = new Vector2(21.12f, 31.125f);
return i;
}
double DecimaltestMethod() 
{
double i;
i = 3.1f;
return i;
}
string StringtestMethod() 
{
string i;
i = "Hr. Hej";
return i;
}

