namespace ringerapi
{
    public class Player
    {
        private readonly int _id;
        private readonly string _name;
        public Player(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public int Id { get{return _id;} }
        public string Name {get {return _name;}}

        public override bool Equals(object obj){
            if(_id == ((Player)obj).Id){
                return true;
            }
            return false;

        }

        public override int GetHashCode(){
            return _id.GetHashCode() * 17;
        }
    }
}

