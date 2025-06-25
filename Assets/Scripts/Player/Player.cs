using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float InvensibilidadeInicio = 10;
    public float VelocidadeAtual;
    public float VelocidadeInicial;
    public float VelocidadeApuama;

    public float ApuamaTimerAtivo;
    public float ApuamaTimerAtivar;
    public bool Apuama;
    public Rigidbody2D Rigid;

    private Vector2 moveDirection;

    public int Xp;
    public int MaxXpPerLevel;
    public int Nivel;

    public Transform AreaDeColeta;
    public float range;
    public LayerMask XpLayer;
    public LayerMask VidaLayer;

    public Slider XpSlider;
    public Slider VidaSlider;

    public float Vida;
    public float VidaMaxima;
    public float Resistencia = 1;
    public GameObject Mira;
    public GameObject PowerUpUi;

    public Animator anim;

    public GameObject MostradorEstatisticas;
    private void Start()
    {
        MostradorEstatisticas.SetActive(false);
        Vida = VidaMaxima;
    }
    void Update()
    {
        Inputs();
        XpBar();
        VidaSlider.value = Vida;
        InvensibilidadeInicio -= Time.deltaTime;

        if(InvensibilidadeInicio <= 0)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }

        if(Apuama)
        {
            ApuamaTimerAtivar -= Time.deltaTime;

            if(ApuamaTimerAtivar <= 0)
            {
                VelocidadeAtual = VelocidadeApuama;
                ApuamaTimerAtivo -= Time.deltaTime;
                anim.SetBool("PesDeVento", true);
                
            }
        }

        if(ApuamaTimerAtivo <= 0)
        {
            VelocidadeAtual = VelocidadeInicial;
            ApuamaTimerAtivo = 3;
            ApuamaTimerAtivar = 5;
            anim.SetBool("PesDeVento", false);
        }
    }

    void FixedUpdate()
    {
        Move();

        Collider2D[] AcertouXp = Physics2D.OverlapCircleAll(AreaDeColeta.position, range, XpLayer);
        foreach (Collider2D xp in AcertouXp)
        {
            Xp += xp.GetComponent<XpScript>().XpValue;
            Destroy(xp.gameObject);
        }

        Collider2D[] AcertouVida = Physics2D.OverlapCircleAll(AreaDeColeta.position, range, VidaLayer);
        foreach (Collider2D Regen in AcertouVida)
        {
            Vida += Regen.GetComponent<Regenerador>().Valor;
            Destroy(Regen.gameObject);
        }

        if (Vida <= 0)
        {
            MostradorEstatisticas.SetActive(true);
            Destroy(gameObject);
        }
        if (Vida >= VidaMaxima)
        {
            Vida = VidaMaxima;
        }
    }

    void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        if(moveDirection.x != 0 || moveDirection.y != 0)
        {
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }
        Rigid.velocity = new Vector2(moveDirection.x * VelocidadeAtual, moveDirection.y * VelocidadeAtual); 
    }

    void OnDrawGizmosSelected()
    {
        if (AreaDeColeta == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AreaDeColeta.position, range);
    }

    public void XpBar()
    {
        XpSlider.maxValue = MaxXpPerLevel;
        XpSlider.value = Xp;

        if (Xp >= MaxXpPerLevel)
        {
            MaxXpPerLevel += 10;
            Nivel += 1;
            Xp = 0;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Time.timeScale = 0;
        PowerUpUi.SetActive(true);
        PowerUpUi.GetComponent<DistribuicaoDePowerUps>().Distribuidor();
        
    }

    public void ApuamaMetodo()
    {
        Apuama = true;
    }

    public void TakeDamage(int Dano)
    {
        Vida -= (Dano - Resistencia);
    }

    public void RenerarVida(int Valor)
    {
        Vida += Valor;
    }


}
