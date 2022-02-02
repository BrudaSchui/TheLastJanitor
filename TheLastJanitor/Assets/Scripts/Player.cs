using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private float _speed = 2;
	private float _stamina = 1;
	private Animator _animator;
	public Text _staminaText;

	void Start()
	{
		_animator = GetComponent<Animator>();
	}

	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(x, y).normalized;
		_animator.SetFloat("Move X", x);

		GetComponent<Rigidbody2D>().velocity = direction * _speed * _stamina;

		_stamina -= 1 / 100;
		_staminaText.text = $"Stamina: {_stamina}";
	}

	void Eat()
	{
		_stamina = 1;
	}
}