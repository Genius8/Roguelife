using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
  
   public BoardManager BoardManager;
   public PlayerController PlayerController;

   //private TurnManager m_TurnManager;
   public TurnManager TurnManager { get; private set;}

   private void Awake()
   {
       if (Instance != null)
       {
           Destroy(gameObject);
           return;
       }
      
       Instance = this;
   }

    private int m_FoodAmount = 100;

    public UIDocument UIDoc;
    private Label m_FoodLabel;

   void Start()
   {
    m_FoodLabel = UIDoc.rootVisualElement.Q<Label>("FoodLabel");
    m_FoodLabel.text = "Food : " + m_FoodAmount;
       //m_TurnManager = new TurnManager();
    TurnManager = new TurnManager();
    TurnManager = new TurnManager();
    TurnManager.OnTick += OnTurnHappen;
    
    BoardManager.Init();
    PlayerController.Spawn(BoardManager, new Vector2Int(1,1));
   }

    void OnTurnHappen()
{
    m_FoodAmount -= 1;
    //Debug.Log("Current amount of food : " + m_FoodAmount);
    m_FoodLabel.text = "Food : " + m_FoodAmount;
}
}