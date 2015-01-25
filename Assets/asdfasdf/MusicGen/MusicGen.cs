using UnityEngine;
using System.Collections;

class MusicLoopData{
	public int BackToIndex;
	public int NumLoops;
	public MusicLoopData(int index,int num){
		BackToIndex = index;
		NumLoops = num;
	}
}

class MusicTrack{
	/*
	 * I#		instrument
	 * P#		pitch
	 * V#		volume
	 * N#		play note with delay after
	 * R#		rest
	 * [#		loop
	 * ]		end loop
	 */
	string str;
	
	int instrument = 0;
	float pitch = 1;
	float volume = 1;
	
	int index = 0;
	
	Stack LoopStack;
	
	float timer;
	public MusicTrack(string s,float delay = 0){
		LoopStack = new Stack();
		str = s;
		timer = delay;
	}
	
	void PlayNote(MusicGen gen){
		gen.Play(instrument,volume,pitch);
	}
	void wait(MusicGen gen){
		timer += gen.BeatTime*GetNumber();
	}
	
	float GetNumber(){
		char c = str[index];
		string word = "";
		while(char.IsDigit(c) ||  c == '.'){
			word += c;
			c = str[++index];
		}
		if(c != ';')
			--index;
		return float.Parse(word);
	}
	
	public void Update(MusicGen gen,float dt){
		if((timer -= dt) < 0){
			while(true){
				char s = str[index++];
				if(index == str.Length) index = 0;
				
				switch(s){
				case 'N':
					PlayNote(gen);
					wait(gen);
					break;
				case 'R':
					wait(gen);
					break;
				case 'I':
					instrument = (int)GetNumber();
					break;
				case 'P':
					pitch = GetNumber();
					break;
				case 'V':
					volume = GetNumber();
					break;
				case '[':
					int numloops = (int)GetNumber();
					LoopStack.Push(new MusicLoopData(index,numloops));
					break;
				case ']':
					MusicLoopData data = (MusicLoopData)LoopStack.Peek();
					if(--data.NumLoops <= 0)
						LoopStack.Pop();
					else
						index = data.BackToIndex;
					break;
				}
				if(timer > 0)
					break;
			}
		}
	}
}

public class MusicGen : MonoBehaviour {
	public AudioClip[] Sounds;
	public GameObject SoundSource;
	
	
	public float BeatsPerMinute = 180;
	public float MasterVolume = 1;
	
	bool ready = false;
	
	public readonly float BeatTime;
	
	MusicTrack[] Tracks;
	
	public MusicGen(){
		BeatTime = 60f/BeatsPerMinute;
		
		Tracks = new MusicTrack[4];
		//Tracks[0] = new MusicTrack("I0;P1;N1;P.75;N1;P1;N1;P.75;N1;P1.104;N1;P.75;N1;P1.104;N1;P.75;N1;");
		Tracks[0] = new MusicTrack("I0;[2;P1;N1;P.75;N1;][2;P1.104;N1;P.75;N1;]");
		Tracks[1] = new MusicTrack("I1;N1;",BeatTime*8.5f);
		Tracks[2] = new MusicTrack("I2;[2;P3.5N.75;P3.3N.25;P3.5N.5;P3.78N.5;P3.5N2;R4][4;P3.5N.75;P3.3N.25;P3.5N.5;P3.78N.5;P3.5N2;P4.81N1;P4.45N1;P3.9N1;P3N1;]R16;",BeatTime*16);
		Tracks[3] = new MusicTrack("I2;V.5;R31.85;[9999;[4;P.6N2;P.45N2;P.6624N2.5;P.43N.5;P.48N.5;P.53N.5;]R32;];");
		//Tracks[3] = new MusicTrack("I4;R3.25;P3N.5;P2.8N.5;P2.5N2;");
		//Tracks[3] = new MusicTrack("I5;P1.25N4;P1.5N4;");
	}
	
	void Start(){
		ready = true;
	}
	
	public void Play(int index,float volume,float pitch){
		GameObject obj = (GameObject)this.Instantiate(SoundSource);
		AudioSource audio = obj.audio;
		audio.playOnAwake = true;
		audio.pitch = pitch;
		audio.volume = volume*MasterVolume;
		audio.clip = Sounds[index];
		audio.Play();
	}
	
	void FixedUpdate(){
		if(!ready) return;
		
		foreach(MusicTrack track in Tracks)
			if(track != null)
				track.Update(this,Time.fixedDeltaTime);
	}
}
