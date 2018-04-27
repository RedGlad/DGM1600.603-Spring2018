public class George : MonoBehaviour {
    // This is the Main Class. It is also the script.
    // Everything George does will be in this script.

    void MakePie() {
        // George will make a pie every time this function is called.
    }
    void GivePie() {
        // George will give a pie to someone else.
    }
    void EatPie() {
        // George will eat pie in this function.
    }
    
    public class Mary {
        // This is a sub class. I can use it to group things.
        // Everything in this subclass would be interactions George has with Mary.

        void MaryEatPie() {
            MakePie();
            GivePie(); 
            // George will make a pie and give it to Mary.
        }
        void MaryDies() {
            // Mary dies in this funcion.
            // George must have something to do with it because it's in his main class.
        }
    }
}